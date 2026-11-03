# AGENTS.md

Instructions for AI coding tools working in this repository. This file points to the project's living docs instead of repeating them. Read those first.

## Read These First

- **What we are building and why:** [docs/requirements.md](docs/requirements.md)
- **How the system is built, and what is still undecided:** [docs/design.md](docs/design.md)
- **Known risks and pending approvals:** [docs/risks.md](docs/risks.md)
- **Setup, running, and testing:** [README.md](README.md)
- **Branching, reviews, and Definition of Done:** [CONTRIBUTING.md](CONTRIBUTING.md)

If this file and one of those documents disagree, the document wins; flag the conflict.

## Quick Facts

- Unity **6000.6.6f1**, C#, Universal Render Pipeline.
- Repository: https://github.com/2026-2027-Capstone-Projects/OregonVR
- Runtime code goes in `Assets/Scripts/` (assembly `OregonVR.Runtime`). Tests go in `Assets/Tests/PlayMode/` (assembly `OregonVR.PlayModeTests`).
- Run tests: Unity **Test Runner → EditMode → Run All**. CI runs the same tests on every pull request.

## Conventions

- PascalCase for classes, methods, and public members; camelCase for private fields and locals.
- One MonoBehaviour per file; the file name matches the class name.
- Always commit the `.meta` file alongside any asset you add, move, or rename.
- Never commit `Library/`, `Temp/`, `Logs/`, `UserSettings/`, IDE files, or build output (see `.gitignore`).
- All changes reach `main` through a reviewed pull request.

## Confidentiality (rules AI tools must follow)

- Never paste passwords, API keys, tokens, Unity license files, or account credentials.
- Unity C# code from this repo may be shared only with the team's approved Claude account, and only once partner permission is confirmed (P4 in docs/risks.md).
- Vegetation photos, videos, 3D assets, and other captured garden data must not be uploaded to any AI tool until the partner approves.
- Partner meeting recordings, transcripts, and notes must not be entered into AI tools without partner approval.
- When unsure, stop and ask the AI Coordinator (Swathi Pappoppula).

The AI Coordinator reviews this file at the end of every sprint.
