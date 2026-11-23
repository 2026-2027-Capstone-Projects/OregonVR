# RFC: Capture and Reconstruction Tool for Oregon Garden VR

**Project 40: Oregon Garden VR**
**Author:** Swathi Pappoppula (pappopps@oregonstate.edu)
**Status:** Accepted, pending verification (checks 1–6 not yet run on the headset).

## Problem and Context

This project is an explorable VR garden of Oregon vegetation, built for our project partner, Dr. Raffaele De Amicis. His goal is a reusable pipeline for turning real plants into VR assets, and the garden is the demonstration of that pipeline. Instead of modeling plants by hand, we capture real plants on a phone and reconstruct them with existing Gaussian splatting tools. The project brief asks for:

- a documented pipeline from capture to VR
- a workflow for cleaning, cropping, scaling and orienting assets
- several assets combined into one garden at correct scale
- acceptable VR performance with measured results

The brief also says we are not expected to develop a new splatting algorithm, so our choices are among existing tools.

Gaussian splatting rebuilds a real object from photos or video as hundreds of thousands of small, soft, colored blobs called Gaussians, or "splats." Together they reproduce the object's shape and appearance from any angle. The headset has to draw every splat in every frame. So the number of splats in a scene directly sets how smoothly it runs, and too many makes VR stutter.

This RFC covers the first stage of our pipeline. The decision is which tool turns our footage into splats, and which file format brings them into Unity. Every later step depends on it: cleaning, placement, scale and performance tuning all work on whatever this tool produces.

Three constraints shape the decision. First, most of the team works on Apple Silicon Macs with no NVIDIA GPU, which rules out CUDA-only trainers on our own machines. Second, Meta's PC VR Link software isn't available on macOS, so we will build for a standalone Meta Quest. That puts us on a mobile GPU, which limits how many splats we can render each frame. Third, we capture on phones outdoors, and plants sway in the wind. Standard Gaussian splatting turns that movement into blur and stray floaters.

Since the first draft, two things have changed. We found that Scaniverse trains splats on the phone itself, which removes the Mac limitation for capture. Our first captures also showed the size of the performance problem. Two plants came out at 630,000 and 660,000 Gaussians, with files of 200–370 MB each ([docs/splat-captures.md](../splat-captures.md)). That is already more than the roughly 400,000 Gaussians one VR renderer reports for a whole scene on Quest 3 [1].

The decision is needed now because we are just starting with Unity and Gaussian splatting tools, and the steps we follow for these first captures will become our pipeline by default. What makes it hard to reverse is the source data. If we keep what we need to regenerate assets, switching tools later is cheap. If we keep only finished splats from a poor tool, we have to go back to the garden and re-shoot every plant, possibly in a different season when the foliage looks different. Our Unity work (cropping, placement and scale) also builds on each imported asset, so every regenerated asset means redoing that work.

If we do nothing, each of us will keep using whichever app we tried first. Assets will arrive in mixed formats, orientations and densities, and no one will be able to regenerate them. And because one plant already exceeds the whole-scene budget, we would find out only at integration that the garden can't run on the headset.

## Options

### Option A: Polycam (cloud) → PLY

Capture on a phone, process in Polycam's cloud, export the splat as PLY, and import it into Unity with the open-source Unity Gaussian Splatting package [5].

- **Benefits:** easy capture, no training on our own machines, consistent results.
- **Costs:** PLY export requires a paid plan ($12.50/month billed yearly or $30/month billed monthly) [4], so the free tier can't produce assets we can use. Processing happens on Polycam's servers, so we give up control over training settings and splat count, and our footage leaves our devices.
- **Right choice when:** the team has a budget for a subscription and values convenience over control of asset size.

### Option B: 3D Splat App (Mac, free) → PLY

Capture photos or video on a phone, train on our Macs with 3D Splat App, export PLY, and import it into Unity.

- **Benefits:** free, runs entirely on-device, includes camera alignment (COLMAP) and training in one app, and lets us set a maximum splat count [2], which is the setting our Quest performance budget depends on. We keep our original images, so any asset can be retrained.
- **Costs:** an extra step, moving footage from phone to laptop. Training uses laptop GPUs, and we haven't measured how long that takes. The app is new with few reviews, and it requires a recent macOS.
- **Right choice when:** we need direct control over splat count at training time and want a free, reproducible pipeline.

### Option C: Scaniverse (on the phone, free) → PLY, decimated before Unity

Capture and train directly on a phone with Scaniverse [11], export PLY, reduce each plant to a fixed splat count with splat-transform's decimation [12], and import it into Unity.

- **Benefits:** free, and it trains on the phone in about a minute per plant from our own captures, so no laptop GPU is needed. Footage stays on the device. It also exports SPZ, a compressed format about 90% smaller than PLY [10].
- **Costs:** Scaniverse is free, but it has no splat-count setting, and our captures came out at 630,000–660,000 Gaussians each, so every plant needs a separate decimation step that may lose fine detail such as thin leaves. We also cannot export the raw frames, so regenerating an asset from scratch means re-shooting it.
- **Right choice when:** the team captures on phones and needs fast, free and consistent results, as long as decimated plants still look acceptable on the headset.

### Option D: Do nothing

Each member keeps using whichever tool they tried first and converts files by hand when an import fails.

- **Benefits:** costs nothing this week.
- **Costs:** they arrive at integration: mixed formats, orientations and densities, no record of how each asset was made, and no way to shrink an asset except re-shooting it. Our first captures already exceed the Quest's whole-scene budget (see Analysis), so with no agreed size limit the garden would not run on the headset.
- **Right choice when:** the deliverable is a single one-off demo, which this project is not.

## Analysis

Performance is the main deciding factor. A VR fork of the Unity splat renderer holds 72 fps on a standalone Quest 3 only up to about 400,000 Gaussians for the whole scene [1]. Because the fork isn't the aras-p package we use [5], we treat that figure as an estimate. Our own captures show how tight the budget is. Two Scaniverse plants came out at 630,000 and 660,000 Gaussians, with PLY files of 200–370 MB ([docs/splat-captures.md](../splat-captures.md)). One raw plant already exceeds the budget, and five would be about eight times over, so every plant must be reduced to about 80,000 Gaussians in a five-plant scene. The options differ in where that reduction happens. 3D Splat App caps splat count during training [2], and Polycam gives no control [3]. Scaniverse [11] has no splat-count setting, so we reduce each plant afterward with splat-transform, which merges similar splats to preserve appearance [12]. That adds a step per asset and may lose fine detail.

On cost, Polycam needs a paid plan to export PLY [4], while the other tools are free. On complexity, Scaniverse trains on the phone in about a minute per plant with no laptop step, while 3D Splat App adds a transfer to the Mac and training time we haven't measured. All of the tools export PLY, which our Unity package imports [2][4][5], and our Scaniverse files have already imported without errors. For privacy, Scaniverse and 3D Splat App keep footage on our devices, while Polycam uploads it to its servers. Doing nothing leaves assets that are mixed in size, can't be regenerated, and are too large for the headset. We left out training on HPC or a cloud GPU because phone training already works. The remaining problem is splat count, which decimation solves without a GPU.

Quest rendering issues [6][7] and wind blur [8][9] affect every option. We handle them through verification and by capturing on calm days. Headset frame rate with several plants, and the detail left after decimation, are still unmeasured. Check 6 tests both.

## Recommendation and Verification Plan

We recommend Option C: capture and train on our phones with Scaniverse, archive the full-density PLY, reduce each plant to a fixed splat count with splat-transform, and import it with the Unity Gaussian Splatting package. It is free, it trains in about a minute per plant without a laptop GPU, and our first captures already import into Unity without errors. Decimation supplies the size control our Quest performance budget requires. Because Scaniverse cannot export raw frames, the archived full-density PLY is our source data: if the budget changes, we re-decimate from it instead of re-shooting. 3D Splat App (Option B) is the fallback if decimated plants lose too much detail, because it caps splat count during training instead of after it.

**Verification** (owner: Swathi Pappoppula, by December 2, 2026). Take five sample plants through the full pipeline, each decimated to 80,000 Gaussians. The pipeline passes only if all of these hold:

1. **Import:** each decimated PLY imports into the Unity Gaussian Splatting package with no errors, and the project builds and runs on the Quest.
2. **Rendering in VR:** on the headset, each splat stays fixed in the world during head movement and looks the same in both eyes.
3. **Scale and orientation:** a measured real-world dimension of each plant is within ±5% in Unity, and up is correct after one documented transform.
4. **Visual match:** views of each decimated plant from three fixed positions in Unity match the same views in Scaniverse's viewer, with no missing regions, no added floaters, and no visible people.
5. **Reproducibility:** a second team member can produce the same decimated asset from the archived full-density PLY using only our written steps.
6. **Frame rate:** with all five plants in one scene at final scale, a fixed 60-second walk on the Quest, recorded with OVR Metrics Tool, stays at or above 72 fps throughout.

**If it fails:** if check 1 or 3 fails because of Scaniverse, or check 4 fails because decimation removes too much detail, we switch to 3D Splat App (Option B), with Polycam (Option A) as the next fallback. If check 2 fails, the problem is the renderer, not this decision, and it gets its own RFC. If check 5 fails, the RFC stays at "pending verification" until our written steps are fixed. If check 6 fails, we lower the per-plant count and re-decimate from the archived PLY; if plants no longer pass check 4 at a count that holds 72 fps, we reduce the number of plants per scene or open a rendering RFC.

## Constraints

**Licensing:** the Unity Gaussian Splatting package is MIT-licensed [5], as are SPZ [10] and splat-transform [12], so we can use and modify all three in the partner's project. Under Niantic Spatial's Terms of Service, which cover Scaniverse, we own the 3D models we generate, but Niantic receives a perpetual, royalty-free license to user content and output, including for training its AI models, and the app is licensed only for personal, non-commercial use; business use falls under separate Business and Developer Terms [13]. This puts two conditions on the recommendation: we keep scans in the app private and do not upload or share them, and if Dr. De Amicis plans any commercial use of the garden, we must confirm the Business Terms allow it before delivery, or switch to 3D Splat App. Polycam is a paid service governed by its own terms.

**Data use and privacy:** Scaniverse processes captures on the phone, and we do not use its paid cloud processing or share scans publicly, so footage stays on our devices. Polycam (the fallback) would upload footage to its servers. The garden is a public space, so we obtained permission from the garden before capturing, avoid capturing visitors, and crop out anyone who appears; check 4 confirms no people remain in the final asset.

## Delegation and Validation

**What I handed to AI tools:** I used Claude to research Gaussian splatting tool options, pricing, file-format support and licenses, and to help reword and restructure this RFC during revision.

**What checks made that reasonable:** each price was checked against the vendor's own pricing page, and each license against the project's LICENSE file or published terms. File-format support was confirmed by importing our own Scaniverse PLYs into Unity rather than trusting documentation. Every measurement in this RFC (Gaussian counts, file sizes, training time) comes from our own captures, recorded in [docs/splat-captures.md](../splat-captures.md). Our repository has no tests or CI for this pipeline, so the verification plan above is the gate before the decision is final.

**Where I validated myself:**

1. **The splat budget.** A wrong budget means re-shooting every plant, possibly in a different season, so I compared the outside 400k figure against our own measured counts rather than accepting an AI summary.
2. **Scale and orientation.** Every placement in Unity builds on it, so check 3 uses a real tape-measured dimension.
3. **Licenses and terms.** A wrong reading could block the partner from using the garden, so I read the Scaniverse and package terms myself.

## Decision

Accepted, pending verification: the team uses Scaniverse with decimation to 80,000 Gaussians per plant (Option C), with 3D Splat App as the fallback. Checks 1–6 have not yet run on the headset. If they fail, this decision is revisited as described in the verification plan.

## References

1. ninjamode, Unity-VR-Gaussian-Splatting. https://github.com/ninjamode/Unity-VR-Gaussian-Splatting
2. Laan Labs, 3D Splat App (Mac App Store). https://apps.apple.com/us/app/3d-splat-app/id6760239941
3. THE FUTURE 3D, "Polycam." https://www.thefuture3d.com/software/polycam
4. Polycam, "What File Types Can Polycam Export?" https://learn.poly.cam/hc/en-us/articles/27756102599572
5. Unity Gaussian Splatting (aras-p). https://github.com/aras-p/UnityGaussianSplatting
6. aras-p/UnityGaussianSplatting, Issue #151. https://github.com/aras-p/UnityGaussianSplatting/issues/151
7. Radiance Fields, "Gaussian Splatting Unity Plugin gets VR Support." https://radiancefields.com/gaussian-splatting-unity-plugin-gets-vr-support
8. "3D Gaussian Splatting Methods for Real-World Scenarios," ISPRS Annals X-G-2025. https://isprs-annals.copernicus.org/articles/X-G-2025/641/2025/
9. Tzathas et al., "Adaptive Spatio-Temporal 3D Gaussian Splatting for Scenes with Oscillatory Motion," Computer Graphics Forum 45(2), 2026. https://diglib.eg.org/bitstream/handle/10.1111/cgf70410/cgf70410.pdf
10. Niantic / Scaniverse, "SPZ: an open-source file format for Gaussian splats." https://scaniverse.com/news/spz-gaussian-splat-open-source-file-format
11. Niantic Spatial, Scaniverse. https://scaniverse.com
12. PlayCanvas, SplatTransform documentation. https://developer.playcanvas.com/user-manual/splat-transform/
13. Niantic Spatial, Terms of Service. https://www.nianticspatial.com/en/terms
