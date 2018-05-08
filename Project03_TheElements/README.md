# CS4331-VR Project 3
### [Demo Link](https://github.com/Trentm95/CS4331-VR/releases/tag/Lit-v1)

### [Video Link](https://streamable.com/38s09)

## Game Description
This is a standalone, first person shooter game where the player must survive as many rounds as possible. Enemies will come in waves, and the player must defeat each wave in order to advance to the next round. The waves will become increasingly harder as the rounds progress. The fighting style revolves around the idea of the four elements - air, water, fire, and earth. The enemies will be elementals, each representing a specific element. The player will wield the power of the four elements in order to defeat these enemies. The player must decide which element to wield depending on the enemy. For example, if the enemy is a fire elemental, the player must wield the element of water in order to defeat it. There is not a finite amount of rounds to win; the player will just last as many rounds as they possibly can.

## Getting Started
We chose to develop our game in [Unity](https://unity3d.com/), and we imported free and paid model assets from the [Unity Asset Store](https://assetstore.unity.com/). The scripts were to be done in Unity's default programming language, C#. For the floor and projectile designs, we utilized [Adobe Photoshop](https://www.adobe.com/products/photoshopfamily.html) to create our own designs.

## Duties
### Trent
- Set Up Oculus Rift & Oculus Touch Controls
- Shooting Mechanics
- UI
- Music/Sounds

### Christine
- Map Creation
- Enemy AI
- Progression Interface
- Round Control/Wave Spawns

### Michael
- Projectiles
- Particle Systems

## Screenshots
### Elementals
<*insert fire*>
<*insert water*>
<*insert earth*>
<*insert air*>

### Map
<*insert floor and skybox*>

### Oculus Touch Controls
<*insert in-game hands*>

### Projectiles
<*insert fire*>
<*insert water*>
<*insert earth*>
<*insert air*>

### Start/End Screens
<*insert start*>
<*insert end*>

### In-Game UI
<*insert UI from top of screen*>

## Obstacles & Issues
### Testing
For those of us that did not have an Oculus Rift at our disposal, we needed to utilize the normal FPS controls that Unity provides in their character package. This caused some difficulties when testing features as things developed for the FPS controls would not work for the Oculus and vice versa. Luckily, the team was very good with communication amongst one another and we were able to solve problems quickly.

### AI Attacks
A 5 second delay was implemented at the start of each round to give the player time to view their enemies and prepare. This 5 second delay was done using Unity's *coroutine*. This caused some issues as Christine could no longer put the enemy attack logic in the update function to be called every frame. Christine needed the enemy to attack repeatedly if it was in range of the player, therefore she needed some way to loop the attack; however, a *coroutine* does not loop. Christine looked into using a *while* loop, but this caused Unity to freeze. Eventually, she found a way to utilize Unity's *InvokeRepeating* function in order to call the attack function over and over. It would repeat until the enemy was no longer in range of the player. Once the enemy is out of range, Unity's *CancelInvoke* function would cancel the attack until the enemy is in range of the player again.

<*insert Michael's issues*>

<*insert Trent's issues*>

## Conclusion

## References
* [Oculus Docs](https://developer.oculus.com/develop/)
* [Sound Effects](http://www.wowhead.com/sounds)
* [Projectile Tutorial](https://www.youtube.com/watch?v=DEtZUeVY9qk)

## Source Control Timeline
<*insert timeline*>
