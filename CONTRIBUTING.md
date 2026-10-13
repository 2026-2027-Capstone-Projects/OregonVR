# Contributing Guide

This guide explains how to set up, develop, test, review, and release contributions to OregonVR.

## Code of Conduct

Treat teammates respectfully, provide constructive feedback, communicate blockers early, and protect confidential project information. Report concerns to the Project Manager or instructor.

## Getting Started

Clone the repository:

```bash
git clone https://github.com/swath1p/OregonVR.git
cd OregonVR
```

Follow the setup instructions in `README.md`. The team will add the technology stack, dependencies, environment setup, and commands for running the application once they are established. Never commit passwords, API keys, or other secrets.

## Branching & Workflow

Use `main` as the default branch. Create a descriptive branch for each task, such as `feature/navigation`, `fix/loading`, or `docs/setup`. Submit changes through a pull request rather than pushing directly to `main`. Rebase your own branch when needed to incorporate recent changes.

## Issues & Planning

Track tasks and bugs in the team's GitHub Issues or project board. Each task should have a description, acceptance criteria, and an assigned owner. Communicate blockers early and update task status as work progresses.

## Commit Messages

Use clear commit messages that describe the change. Examples:

- `feat: add VR navigation`
- `fix: correct loading behavior`
- `docs: update setup instructions`

Reference the related issue when applicable.

## Code Style, Linting & Formatting

Write readable, consistent, and maintainable code. The team will document the chosen formatter, linter, configuration files, and exact commands once the technology stack is established.

## Testing

Test new features and bug fixes before submitting a pull request. Add or update automated tests when appropriate. The team will document its test framework, test commands, and coverage requirements once configured.

## Definition of Done

A contribution is complete when it meets the task's requirements, relevant tests pass, at least one teammate reviews and approves it, documentation is updated, and required linting, security, and CI checks pass before merging.

The team will track how each requirement is enforced. Since some tools are not yet set up, the following gates will be implemented during Sprint 2.

| Check | Enforcement | Owner | Target Sprint |
|---|---|---|---|
| Tests | Automated test suite | Swathi| Sprint 2 |
| Code review | GitHub pull request approval | Shreya | Sprint 2 |
| Documentation | Pull request checklist | Bryden | Sprint 2 |
| Linting | Linter and CI job | Swathi | Sprint 2 |
| Security | Secret-scanning check | Shreya | Sprint 2 |
| CI | GitHub Actions workflow | Bryden | Sprint 2 |

Once implemented, the team will update this table with the actual test files, configuration files, or CI jobs that enforce each check.

## Contribution Norm

Every student must own at least one piece of accepted work per sprint.

- **Where work lives:** Code and tests belong in the GitHub repository, tasks in GitHub Issues or the project board, and documentation or research in the repository or the team's approved system. Partner deliverables belong in the partner's system.
- **What counts as accepted:** A pull request is approved and merged, an issue or ticket is closed with its outcome, or a document is reviewed and approved. Partner work must be accepted through the partner's process.
- **Making contributions achievable:** Tasks should be small enough to complete within a sprint. Team members should pair when helpful and aim to review pull requests within two business days.
- **Contribution evidence:** Each student records their owned work with a link or ID, whose work they reviewed and one specific change they requested, and their most consequential contribution and how the team knows it works. If no work was accepted, they must state that honestly.
- **Decision leadership:** Each sprint, record who chaired a decision and what decision they drove to a conclusion. Every student must chair at least one decision per term.

Mechanical changes, such as formatting-only updates or bulk renames, do not count as accepted contribution evidence. Focus on meaningful work and explain what it accomplished and how its success was verified.

## Pull Requests & Reviews

Pull requests must describe the changes, reference the related task when applicable, and report testing performed. Reviewers should check correctness, readability, tests, documentation, and security. At least one teammate other than the author must approve before merging. Required CI checks must pass before merging.

## CI/CD

The team will configure continuous integration to run relevant tests and quality checks. The team will document the pipeline, mandatory jobs, and how to review failed logs once CI is established.

## Security & Secrets

Never commit passwords, API keys, credentials, or unauthorized confidential information. The team will establish secret and dependency scanning during Sprint 2.
Report exposed secrets or security concerns to the AI Coordinator (Swathi Pappoppula) immediately

## Documentation Expectations

Update `README.md` and relevant project documentation when setup instructions, features, or technical decisions change. Keep comments clear and document important assumptions.

## Support & Contact

Ask project questions through Microsoft Teams. Contact the repository maintainer for GitHub questions and the Project Manager or instructor for unresolved blockers.

**Repository maintainer:** Swathi Pappoppula

**Project Manager:** Shreya Suresh

**AI Coordinator:** Swathi Pappoppula 

**Quality Owner:** Bryden Takayama
