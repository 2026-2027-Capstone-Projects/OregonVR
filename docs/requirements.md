## Problem Statement
The Oregon Garden VR project aims to provide an immersive virtual experience of Oregon garden environments. Through Unity and 3D reconstruction techniques such as Gaussian Splatting, users will be able to explore digitally reconstructed vegetation and garden spaces. 

## Functional Requirements
### FR1: Virtual Garden Environment
The system should display a 3D garden environment within Unity. 

Acceptance Criteria: 
- A garden scene can be opened in Unity
- The scene displays the available garden assets

### FR2: Support VR Navigation
The system should support a movement ability.

Acceptance Criteria: 
- Users can navigate the scene using supported controls

### FR3: Display reconstructed vegetation
The system should show realistic vegetation.

Acceptance Criteria: 
- At least one reconstructed vegetation asset appears in the scene

### FR4: Support vegetation identification
The system should be able to properly identify the correct vegetation

Acceptance Criteria: 
- The user can select a supported plant and view its information

## Non-Functional Requirements
- The experience should run on the team's selected VR hardware
- The Unity project should be reproducible from the repository
- Navigation should be comfortable and intuitive
- The system should prioritize stable VR rendering performance

## Constraints
- Development is limited by available VR hardware and computing resources
- Reconstruction quality depends on available garden imagery
- The application must work with the team's selected Unity version and compatible packages

## Success Metrics
- A user can launch the garden environment on the intended device
- The project displays at least one reconstructed garden element
- The required core interactions work in a test scene

## Non-Goals
- Recreating every garden in Oregon
- Supporting every available VR headset
- Providing real-time reconstruction of entire gardens

## Open Questions
- Which headset will be the primary target?
- Which Gaussian Splatting package will be used?
- Which garden will be reconstructed first?
