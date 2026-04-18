
<h3  align="center">Incremental Miner</h3>

```
This project implements a save system and Localization for a Unity game supporting:

• Multiple user profiles
• Multiple save slots
• Save preview system
• Localization support
• Persistent game data

Each user has independent save files stored in the persistent data path.
```
```
Architecture:
- UserManager
UserManager allows creation, deletion, and selection of user profiles. 
Each user has an independent save directory, 
ensuring that save data is isolated between players.

- SaveManager
UserManager allows creation, deletion, and selection of user profiles. 
Each user has an independent save directory, 
ensuring that save data is isolated between players.

- GameData
GameData is a simple data container used by the SaveManager 
to store and retrieve player progress.

- LocalizationManager
LocalizationManager loads language data from localization files 
and provides translated text to UI elements. 
It also triggers UI refresh when the language changes.

- GameMenuUI
Simple demonstration of a game
```
```
FEATURE
• Create / Delete / Select User
• Save to 5 slots
• Load saved game
• Save preview (Level + Gold)
• Localization system
• UI integration
```
```
HOW TO RUN
1. Open the project in Unity 2021+
2. Open the MainMenu scene
3. Press Play
4. Create a user
5. Start a new game
6. Save / Load using the save menu
```
```
User & save Location:
Application.persistentDataPath/Users/<username>/
C:\Users\<username>\AppData\LocalLow\DefaultCompany\AgatePortingTestFadliBirdieZ\Users
```