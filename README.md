# HW4
## Devlog
In this project, I used the Model-View-Controller pattern to keep my code organized and easy to manage. The control side of the game is defined by the Bird_Controller class. This script acts as the brain of the player, handling all the physics and input logic. For example, in the Update() method, it listens for the Space key to make the bird jump by changing the velocity of "myRigidBody". The controller only cares about the game rules and movement; it doesn’t actually handle things like the score text or sound effects.

The view side of the game is defined by the UI_Manager and Audio_Manager classes. These scripts are responsible for what the player sees and hears. The UI_Manager updates the scoreText to show points, and the Audio_Manager uses myAudioSource.PlayOneShot() to play sounds like jumpSound or coinSound. By separating these, I can change the way the game looks or sounds without having to mess with the code that makes the bird jump.

To make the view and control parts work together without being stuck to each other, I used events and a Singleton. The Bird_Controller uses events like Pass_Obstacle_Event to shout whenever something happens. The UI_Manager uses a Singleton (using Instance) so it's easy to find, and it listens for those shouts to update the score. This keeps the systems decoupled, which means the bird doesn't need to know the UI exists to do its job. This makes the code much cleaner and prevents bugs.

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
