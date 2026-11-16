# Oregon Garden VR - Technical Design Review
**Reviewer:** ChatGPT (AI Agent)  
**Document Reviewed:** `docs/design.md`

## 1. AI Agent Review

### Question 1: Could someone who hasn't read the code follow how the system works from this document alone? Where did you get lost?

The document explains the main components of the system and the technologies being used. It provides enough information to understand that Unity handles the VR environment, Gaussian Splatting is being evaluated for creating realistic garden models, and C# scripts handle interactions. However, the document could better explain how reconstructed assets are imported into Unity and how users will eventually interact with those assets.

### Question 2: Are the diagrams kept where they change with the document? Which part of the design needs a diagram it doesn't have?

Section 2 references a system architecture diagram, but the diagram was not visible in the provided document text. The team should verify that the diagram renders correctly in GitHub and can be updated alongside the technical design document. A diagram showing the reconstruction process, Unity environment, VR interaction system, and deployment process would help explain how the components connect.

### Question 3: Does the design solve the problem the team presented? Is a credible alternative missing for the decision the team is least sure of?

The design addresses the main goal of creating an immersive VR garden experience where users can explore and learn about Oregon vegetation. Gaussian Splatting is being evaluated to create realistic environments. One alternative worth considering is combining traditional 3D models with Gaussian Splatting. This would allow the team to use realistic reconstructed environments while keeping individual plants interactive through standard Unity objects.

### Question 4: What would break if the assumption the design rests on most changed?

One important assumption is that the selected VR headset will support the rendering approach and deployment process. If the headset cannot run Gaussian Splatting efficiently or does not support the planned build format, the team may need to change the rendering method or build configuration. The current CI pipeline produces Windows builds, which may not be compatible with standalone VR headsets such as Meta Quest.

### Question 5: What single change would you make first?

The first change would be clarifying the target VR hardware and ensuring that the build pipeline supports it. This is important because the headset choice affects rendering performance, Unity build settings, and the distribution process. Confirming the target hardware would help the team make better decisions about Gaussian Splatting and deployment.

## 2. Prioritized Feedback

| Priority | Feedback | Planned Action |
|----------|----------|----------------|
| High | Target headset and current Windows build may not be compatible | Clarify hardware requirements and update deployment documentation |
| High | Architecture diagram could not be verified | Verify that the diagram renders correctly in GitHub |
| Medium | Reconstruction-to-Unity workflow lacks detail | Expand the interface description after selecting the reconstruction tool |
| Medium | Hybrid rendering approach is not discussed | Document it as an alternative in a proposed ADR |
| Low | Plant interaction and information flow need more detail | Expand documentation as the prototype develops |

## 3. Planned Design Improvements

Based on the review, the team should prioritize clarifying the VR deployment target and verifying the system architecture diagram.

### 3.1 VR Hardware Compatibility

The technical design document should explain whether the application will run on a standalone VR headset or a PC-connected headset. This decision affects Unity build settings, rendering performance, and deployment requirements. Once the target headset is confirmed, the CI pipeline should be updated to produce a compatible build.

### 3.2 System Architecture Diagram

The team should verify that the existing architecture diagram renders correctly in GitHub and is maintained alongside the technical design document. The diagram should clearly show the relationship between the reconstruction pipeline, Unity environment, VR interactions, testing, and deployment.

### 3.3 Rendering Alternatives

The team should consider creating an Architecture Decision Record (ADR) comparing the following approaches:

- **Gaussian Splatting:** Provides realistic reconstructions but may introduce performance and compatibility issues.
- **Traditional 3D Modeling:** Provides greater control over individual objects and interactions but requires additional modeling work.
- **Hybrid Approach:** Combines Gaussian Splatting for realistic environments with traditional 3D models for interactive vegetation.

The final decision can remain open until the team completes testing and evaluates performance on the selected VR hardware.

## 4. Review Summary

The technical design document provides a good overview of the current system, including its technology stack, interfaces, testing process, and deployment plans. The most important improvements involve confirming hardware compatibility, verifying the system architecture diagram, and documenting alternative rendering approaches.
