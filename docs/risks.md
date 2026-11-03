# Risk Register

This is the project's **only** risk register. It covers business, technical, and team risks for Oregon Garden VR, plus every external prerequisite the project is waiting on. The Project Manager (Shreya Suresh) reviews and updates it at the end of every sprint.

## 1. Ranking

Risks are ranked by likelihood × impact on the Fall Week 10 walking skeleton:

- **High** – could delay development significantly, block a core feature, or threaten a milestone.
- **Medium** – could cause noticeable delay or force an implementation change.
- **Low** – limited impact; can be handled without major changes.

## 2. Risks (ranked, highest first)

| ID | Rank | Category | Risk | Owner | Mitigation | Status |
|---|---|---|---|---|---|---|
| R1 | High | Technical | Gaussian Splatting assets may not render at a stable VR frame rate. | Swathi Pappoppula | Test one splat asset on the target headset early; keep a mesh-based fallback for vegetation. | Open |
| R2 | High | External | The team does not yet have confirmed access to a VR headset for development and testing. | Shreya Suresh | Request a headset through the partner (P2); use Unity's XR Device Simulator until one is available. | Open |
| R3 | High | Technical | Unity, XR packages, and the chosen splatting plugin may be incompatible with each other. | Bryden Takayama | Pin Unity 6000.6.6f1 and package versions; trial the plugin on a separate branch before adopting it. | Open |
| R4 | High | Business | The production target (distribution channel and target hardware) has not been agreed with the partner, so the Week 10 deployment could miss its target. | Shreya Suresh | Get written agreement from Dr. De Amicis (P1). | Open |
| R5 | Medium | Technical | CI depends on a Unity license account; if its credentials expire or change, CI stops running tests. | Bryden Takayama | Use a dedicated CI Unity account without 2FA (P5); document how to refresh the license secret. | Open |
| R6 | Medium | Technical | Large reconstructed assets may bloat the repository and slow load times. | Bryden Takayama | Track large binaries (.fbx, .ply, .splat, .exr) with Git LFS; set a per-asset size budget. | Open |
| R7 | Medium | External | Garden access or recording permissions may limit image and video capture. | Shreya Suresh | Ask the Oregon Garden for recording permission (P3) before scheduling capture trips. | Open |
| R8 | Medium | Business | Requirements may change after partner review, requiring rework. | Shreya Suresh | Review requirements with the partner each sprint; record changes in docs/requirements.md. | Open |
| R9 | Medium | Team | AI tools cannot be used on project code or garden data until the partner approves, which may slow development. | Swathi Pappoppula | Request approval (P4); follow the rules in AGENTS.md until then. | Open |
| R10 | Low | Technical | Documentation may fall behind the code, making the project hard to hand off. | Swathi Pappoppula | Every PR that changes behavior updates the relevant doc (PR checklist). | Open |

## 3. External Prerequisites

| ID | Prerequisite | Needed from | Requested by | Date requested | Status |
|---|---|---|---|---|---|
| P1 | Agreement on the production target (GitHub Releases build on the chosen headset) | Dr. Raffaele De Amicis (partner) | Shreya Suresh | Not yet requested; will ask by Nov 6, 2026 | Not Started |
| P2 | Access to a VR headset for development and testing | Dr. Raffaele De Amicis / OSU lab | Shreya Suresh | Not yet requested; will ask by Nov 6, 2026 | Not Started|
| P3 | Permission to photograph and record vegetation at the Oregon Garden | Oregon Garden staff | Shreya Suresh | Not yet requested; will ask by Nov 6, 2026 | Not Started|
| P4 | Approval to use the team's Claude account on project code | Dr. Raffaele De Amicis (partner) | Swathi Pappoppula | Not yet requested; will ask by Nov 6, 2026 | Not Started |
| P5 | Unity license account for running Unity in GitHub Actions | Unity (free Personal license) | Bryden Takayama | Nov 2, 2026 | Done |

## 4. Safety Net Plan

**Review gates.** Branch protection on `main` requires a pull request with one approving review from a teammate and a passing CI check (Unity Edit Mode Tests). Changes to `ProjectSettings/`, `Packages/manifest.json`, `.github/workflows/`, or build settings also need review from the Quality Owner (Bryden Takayama). *Lands: Nov 3, 2026. Owner: Swathi Pappoppula.*

**Where changes are exercised before users see them.** Every PR runs the Unity tests in CI. Before a build is published, the team installs it on the team's test headset (or runs it in the XR Device Simulator until a headset is available) and walks through the main scene. *Lands: Nov 20, 2026. Owner: Bryden Takayama.*

**Rollback.** A bad change on `main` is undone with `git revert` through a new pull request (never a force-push). Each published build is a tagged GitHub Release, so testers can reinstall the previous release if the newest one is broken. *Lands: Nov 27, 2026, with the first tagged release. Owner: Bryden Takayama.*
