# Oregon Garden VR

A virtual reality experience of the Oregon Garden, built in Unity. Real vegetation is captured with photos and video, reconstructed into 3D with Gaussian Splatting, and placed into a walkable virtual garden.

Capstone Project 40, Oregon State University. Partner: Dr. Raffaele De Amicis.

## Quickstart (from a clean clone)

**Current state:** the repository contains a Unity starter scene (`GetStarted_Scene`), one script (`ModelClickListener`), and two automated tests. The garden scene and splat assets are not in the repository yet.

### Prerequisites

- [Unity Hub](https://unity.com/download)
- Unity Editor **6000.6.6f1** (Unity Hub → Installs → Install Editor → Archive, if it is not listed)
- Git

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/2026-2027-Capstone-Projects/OregonVR.git
   ```
2. Open Unity Hub → **Add** → **Add project from disk** → select the `OregonVR` folder.
3. Open the project with Unity **6000.6.6f1**. The first import takes a few minutes. (A one-time "URP Global Settings Asset has been created" warning is normal.)
4. In the Project window, open `Assets/Scenes/GetStarted_Scene.unity` and press **Play**. The scene runs with no red errors in the Console.
5. Run the tests: **Window → General → Test Runner → EditMode → Run All**. Both tests (`BasicPlayModeTest`, `ModelClickListener_LogsMessage`) pass.

On macOS, Unity's menus (Window, Assets, …) are in the menu bar at the top of the screen, not inside the editor window.

### Troubleshooting

- *"Project was made with a different version of Unity"* — install 6000.6.6f1 exactly; other versions may upgrade the project.
- *Test Runner shows "No tests to show"* — click the editor window, press Cmd/Ctrl + R to refresh, and wait for compilation to finish.

## Continuous Integration

GitHub Actions (`.github/workflows/blank.yml`) runs the Unity EditMode tests on every pull request to `main`, then builds a Windows player. A pull request cannot merge unless the **Unity Edit Mode Tests** check passes.

## Repository Layout

| Path | Contents |
|---|---|
| `Assets/Scenes/` | Unity scenes |
| `Assets/Scripts/` | Runtime C# scripts (`OregonVR.Runtime` assembly) |
| `Assets/Tests/PlayMode/` | Automated tests (`OregonVR.PlayModeTests` assembly) |
| `Assets/Models/` | 3D models and reconstructed assets |
| `docs/` | Requirements, design, and risk register |

## Asset Workflow (planned)

1. Capture photos or video of a plant from many angles (iPhone camera or Polycam).
2. Reconstruct a Gaussian Splatting asset (3D Splat App; tool still under evaluation).
3. Clean up the asset and export it in a format the Unity splatting plugin supports.
4. Import it into `Assets/Models/`, then position and scale it in the garden scene.
5. Test performance on the target headset.

## Documentation

- [Requirements](docs/requirements.md)
- [Technical design](docs/design.md)
- [Risk register and safety-net plan](docs/risks.md)
- [Contributing guide](CONTRIBUTING.md)
- [AI tool instructions](AGENTS.md)

## Team

Swathi Pappoppula · Shreya Suresh · Bryden Takayama
