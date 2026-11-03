# Oregon Garden VR – Requirements

## Problem Statement
The Oregon Garden VR project aims to provide an immersive virtual experience of Oregon garden environments. Using Unity and 3D reconstruction techniques such as Gaussian Splatting, users will be able to explore digitally reconstructed vegetation and garden spaces.

## Functional Requirements

### FR1: Virtual Garden Environment
The system displays a 3D garden environment in Unity.

Acceptance Criteria:
- A garden scene opens in Unity and in a built player without errors.
- The scene displays all garden assets placed in it.

### FR2: VR Navigation
The user can move through the garden scene while wearing the headset.

Acceptance Criteria:
- Using the controller thumbstick (or teleport button), the user can move to any open path in the scene.
- Movement does not pass through walls, trees, or the ground.
- Starting from the spawn point, the user can reach the far end of the scene in under 60 seconds.

### FR3: Display Reconstructed Vegetation
The system shows realistic, reconstructed vegetation.

Acceptance Criteria:
- At least one Gaussian Splatting vegetation asset appears in the scene at the correct scale.

### FR4: Vegetation Identification
The user can select a plant and learn what it is.

Acceptance Criteria:
- Selecting a supported plant shows its name and a short description.
- Clicking a model triggers its click handler (verified in CI by the test `ModelClickListener_LogsMessage`).

## Non-Functional Requirements
- The experience runs on the team's selected VR headset.
- The Unity project can be reproduced from a clean clone by following README.md.
- Navigation is comfortable and does not cause motion sickness in test users.
- Rendering stays at the headset's target frame rate in the test scene.

## Constraints
These are limits the team did not choose:

- **Partner and site:** the project must represent the Oregon Garden, as specified by our partner, Dr. Raffaele De Amicis.
- **Hardware:** development and testing are limited to the VR headsets the partner or OSU can lend the team; the team cannot buy hardware.
- **Budget:** there is no software budget, so reconstruction and splatting tools must be free or free for students.
- **Schedule:** a working walking skeleton is due by Fall Week 10, and the project ends with the academic year.
- **Confidentiality:** captured garden photos, video, and 3D assets, as well as partner meeting content, may not be uploaded to AI tools or shared publicly without partner approval.
- **Site access:** capture is limited to the times and areas the Oregon Garden permits.

## Success Metrics
- A user outside the team can launch the garden environment on the intended headset.
- The scene displays at least one reconstructed garden element.
- The core interactions (navigation, plant selection) work in a test scene.

## Non-Goals
- Recreating every garden in Oregon.
- Supporting every available VR headset.
- Real-time reconstruction of entire gardens.

## Open Questions
- Which headset will be the primary target?
- Which Gaussian Splatting package will be used?
- Which area of the garden will be reconstructed first?
