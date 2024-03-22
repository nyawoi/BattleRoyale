# BattleRoyale for Zumbi Blocks 2

BattleRoyale is a custom PvP game-mode mod for [Zumbi Blocks 2](https://store.steampowered.com/app/1941780/Zumbi_Blocks_2_Open_Alpha/).  
*Despite being named BattleRoyale, it's not actually a Battle Royale mode.*

[battle-royale.webm](https://github.com/nyawoi/BattleRoyale/assets/106277673/87c1c218-b714-41a0-8bdb-b4aecde7a0fc)

## Main Features

- Implements PvP (Player vs Player)
- Smaller island to duel in
- Loadouts are disabled
- Zombies are disabled
- In-game player names and icons are disabled
- Weapons and players are no longer visible on the map

### Other Changes

- Player health has been quadrupled (4x)
- Player stamina has been doubled (2x)
- Melee damage has been quadrupled (4x)
- Players can no longer be staggered
- Players skip dying phase and immediately die
- Players have a three (3) second respawn time
- Healing items are six times as effective
- Decorative corpses have been removed
- Loot amount is almost double
- Small chance for loot to be of higher tier

### Planned Features:

- Semi-random player spawns (prevent players from spawning next to each other)
- Grace period in which no damage can be dealt
- Limited lives system with spectating feature
- Re-implement staggering for certain items (stun grenade)
- Bloodlust perk during Blood Moon
  - Increased damage
  - Increased movement speed?
  - Zombie-like ability to see players through walls?
- Actually implement Battle Royale rules
  - Players only have one life
  - A player-damaging circle will close in on the map
  - Game ends when one player remains
  - Supply drops?
  - Squads???
- Team Deathmatch-like mode
  - Players do not drop inventory on death
  - Temporary invulnerability shield on respawn
  - Disable loot generation?
- Hide and Seek mode
  - Randomly select player to be seeker
  - Give only the seeker a weapon or melee ability
  - Prevent seeker movement until countdown has elapsed

## About

This mod is essentially my modding playground: I get an idea and attempt to implement it.  
A lot of the code seen in this repository will be moved to separate mods or libraries, in the future.
This mod serves as an outlet for creative experimentation, allowing me to see what is and isn't possible.  
Take the disabling of zombies, for example: this functionality can be used for other game-modes, so publishing it as a separate mod to be used in a modpack is ideal.  
Another example is the disabling of decorative corpses in buildings: as a separate library, it will grant modders the ability to customize the world to their liking.
One could replace default models with their own, or even force every painting that spawns to be a chicken painting.  
The main library I'm thinking about creating, though, is a networking library, making it simple for modders to add custom events to the game.
These could even be shared as dependent libraries, and the modding community can watch for any event ID overlap.

To players: I hope you have fun dueling your friends!  
To modders: I hope this project helps you learn a thing or two!
