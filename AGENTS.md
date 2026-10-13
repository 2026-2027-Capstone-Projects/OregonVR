# AGENTS.md

## Project Context
OregonVR is a capstone project building a VR experience of the Oregon Garden
for [partner/organization], partnered with Dr. Amicis.
- **Engine:** Unity [version, e.g., 2022.3 LTS]
- **Language:** C#
- **Target platform:** [e.g., Meta Quest 3 / PC VR]
- **Repository:** https://github.com/swath1p/OregonVR
- Charter, roles, and decisions: see the team charter in Microsoft Teams; ADRs live in `docs/adr/`.

## Conventions
- C# naming: PascalCase for classes, methods, and public members; camelCase for private fields and locals.
- One MonoBehaviour per file; the file name matches the class name.
- Commit only scripts, scenes, prefabs, and `.meta` files. Never commit `Library/`, `Temp/`, or build output (handled by `.gitignore`).
- Follow the Definition of Done and branch workflow in `CONTRIBUTING.md`.

## Confidentiality (rules AI tools must follow)
- Never paste passwords, API keys, tokens, or account credentials.
- Unity C# code from this repo may be shared only with the team's approved Claude account, and only once partner permission is confirmed.
- Vegetation photos, videos, 3D assets, and other captured garden data must not be uploaded to any AI tool until the partner approves.
- Partner meeting recordings, transcripts, and notes must not be entered into AI tools without partner approval.
- When unsure, stop and ask the AI Coordinator (Swathi Pappoppula).

## To Be Added Once Code Exists
| Item | Owner | Target |
|---|---|---|
| Project folder structure and scene layout | Swathi | Sprint 2 |
| Build and run commands | Bryden | Sprint 2 |
| Test framework (Unity Test Framework) and test commands | Bryden | Sprint 2 |
| Linter/formatter config and commands | Swathi | Sprint 2 |
| Approved tool list after partner confirmation | Swathi | Once Dr. Amicis confirms |

The AI Coordinator reviews this file at the end of every sprint.
