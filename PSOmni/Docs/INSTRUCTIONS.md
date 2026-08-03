# PSOmni Development Guide

## Project Vision

PSOmni is a Windows application for synchronizing PlayStation 2 memory cards
between PCSX2 on Windows and AetherSX2/NetherSX2 on Android.

Primary goals:

- One-click synchronization.
- No command line interaction.
- Support multiple games and memory cards.
- Eventually synchronize saves automatically.
- PS OmniSync should optimize for the user experience, not the implementation.

---

## Current Architecture

Configuration
    Application settings.

Domain
    Pure data objects.

Infrastructure
    Interacts with external systems (ADB, processes).

Interfaces
    Contracts for services.

Services
    Business logic.

UI
    Windows Forms.

---

## Design Principles

- Single responsibility.
- No hardcoded game names.
- UI never calls ADB directly.
- Services should not know about WinForms controls.
- Domain objects contain data, not UI logic.
- PSOmni should never overwrite user data without first making the action visible and allowing the user to opt out.

---

## Coding Standards

- Prefer async/await.
- XML documentation on public members.
- Avoid duplicated logic.
- Throw meaningful exceptions.
- Nullable reference types enabled.

---

## Current Alpha Roadmap

✔ Connect automatically

✔ Pull memory cards

✔ Push memory cards

☐ Memory card picker

☐ Settings window

☐ Profiles

☐ Automatic newest-save synchronization

☐ Backup rotation

☐ Companion Android app

---

## Future Ideas

- Auto-detect newest save.
- One-click "Sync Everything."
- Live synchronization.
- Android widget.
- Metadata (size, modified date).
- Cloud synchronization.
- Steam Deck support.

---

## Notes for AI Assistants

When making changes:

- Preserve existing architecture.
- Reuse existing services whenever possible.
- Avoid introducing duplicate abstractions.
- Prefer extending current classes over replacing them.
- Keep UI logic inside MainForm.
- Keep ADB logic inside AdbService.

---

## Repository Review Policy

When requesting code assistance:

- Prefer modifications to existing classes over new classes.
- Inspect the current implementation before proposing changes.
- Give exact file names and insertion locations.
- Do not assume code structure when the repository is available.

---

# Smart Sync Design Guidelines

## Philosophy

Smart Sync is intended to assist the user in synchronizing memory cards, not to make decisions on the user's behalf.

The application should never overwrite user data automatically. The user must always have visibility into proposed changes and the ability to accept or reject them before synchronization occurs.

Manual synchronization (Sync to PC / Sync to Device) must always remain available as explicit, one-click operations.


## Smart Sync Workflow

Smart Sync should operate as a multi-step wizard rather than a single automatic action.

### Step 1 - Scan

Collect synchronization information from both devices.

For each memory card:

- Determine whether the file exists locally.
- Determine whether the file exists remotely.
- Read modification timestamps.
- Read file size.
- (Future) Compare checksums for additional validation.

No files should be modified during this step.

---

### Step 2 - Review Changes

Present only files that require user attention.

Examples include:

- Local version is newer
- Remote version is newer
- File exists only on one device
- Conflict detected

Each proposed action should allow the user to:

- Accept
- Skip

No synchronization occurs until the review is complete.

---

### Step 3 - Execute

Execute only the actions approved by the user.

Skipped items remain unchanged.

---

### Step 4 - Summary

Display a final summary including:

- Files copied to PC
- Files copied to Device
- Files skipped
- Files that failed

No additional confirmation dialogs should be necessary after execution.

---

### Already Synced

Memory cards that are already synchronized should not clutter the review screen.

Instead, display them on a separate page or tab after synchronization is complete for informational purposes only.


## Safety Principles

- Never overwrite data without user approval.
- Favor transparency over automation.
- Present intended actions before executing them.
- Preserve manual Sync to PC and Sync to Device operations.
- Future backup functionality should make accidental overwrites recoverable.


## Future Enhancements

Potential future improvements include:

- Automatic backup rotation (keep only the most recent backups).
- Checksum comparison to detect conflicts beyond timestamps.
- Profile-aware Smart Sync.
- Synchronization history/log.

---

# Architectural Principles

- UI is responsible only for presentation and user interaction.
- Services contain application logic.
- Domain objects represent emulator concepts (MemoryCard, SyncProfile, etc.).
- ADB communication is isolated to AdbService.
- User data should never be modified without an explicit action or confirmation.
- Prefer explicit, readable code over clever implementations.
- Optimize for maintainability over micro-optimizations.

---

# Notes

-every 1.X update after that would be more features/fixes then every 2.0/3.0/4.0 update would be every time we added another device type. 
Like ADB only works for androids, what about syncing with an IPhone? Different PC? Batocera console? Steam Deck? 
As we figure out how to sync the file systems between them we can add more supported devices.