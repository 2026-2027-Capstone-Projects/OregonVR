# Splat Capture Measurements

Measurements from our first Gaussian splat captures.

## Setup

- **Capture and training app:** Scaniverse (Niantic Spatial), free tier, trained on the phone
- **Phone:** Iphone 17 
- **Location:** Oregon Garden (capture permission obtained from the garden)
- **Export format:** PLY 

## Results

| # | Plant | Capture date | Training time (on phone) | Gaussians | PLY size | Unity editor import |
|---|-------|--------------|--------------------------|-----------|----------|---------------------|
| 1 | [Tree] | [2026-11-05] | ~1 min | 630,000 | 370 MB | No errors |
| 2 | [Small bush] | [2026-11-05] | ~1 min | 660,000 | [200–300 MB] | No errors |

## Notes

- How Gaussian counts were read: [e.g., shown in Scaniverse / shown in the Unity asset inspector after import].
- Both captures exceed the ~400,000-Gaussian whole-scene budget reported for Quest 3 by a VR fork of the renderer
  (ninjamode/Unity-VR-Gaussian-Splatting), so each plant must be decimated before use.
- Not yet measured: Quest frame rate, splat count after decimation, visual quality after decimation.
  These are covered by checks 1–6 in the RFC's verification plan (due December 2, 2026).
- Raw PLY files are archived in [location, e.g., team Google Drive folder], not in this repo, because of their size.
