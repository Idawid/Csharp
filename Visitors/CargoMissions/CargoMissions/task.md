# Cargo Missions

## Content

Project contains cargo missions (interface `IMission`) and carriers (`ICarrier`).

### Cargo Missions

Each cargo mission has a name, starting planet, destination planet, reward and field describing if mission has already been completed.
Mission is completed when cargo has been successfully transported from target to destination planet.

Following types of missions are available:

* `ExpressMission` - Mission that cannot take more than specified time to finish. Contains additional information about maximum delivery time.
* `ContestedMission` - Carriers will run into hostile forces during the mission. Contains information about expected strength of enemies.
* `SmugglingMission` - This mission requires moving banned goods between planets. Contains information about risk of being cought.

### Carriers

Each carrier has a name and current location.

* `HyperdriveShip` - Ship equipped with hyperdrive capable of reaching speeds over speed of light. Each ship can have different `hyperdriveSpeed`.
Will complete `ExpressMission` if it's capable of finishing it in time limit, so distance between planets divided by hyperdrive speed is less than time limit.
Will ignore every `ContestedMission`.
Will complete `SmugglingMission` if `hyperdriveSpeed > risk`.
* `Flotilla` - Fleat of ships with information on combat strength.
Will not complete missions other than `ContestedMission`. Will complete `ContestedMission` if all conditions are met:
	* own strength is higher that 1,5 times enemy strenght,
	* starting planet is the same as destination planet.
* `Smuggler` - Ship specialised in smuggling operations. Contains information about expertise and minimal fee.
Will accept `SmugglingMission` if expertise > risk and reward > minimal fee.
Will complete `ExpressMission` if reward is more than half of minimal fee, starting planet is equal to current location and distance between starting and distance planet is less than maximum delivery time.
Will ignore every `ContestedMission`.

## Task

We have a set of cargo missions that need to be completed and group of carriers willing to try and fulfill them.
Each mission will be attempted by all carriers until it gets completed, or there are no more carriers left.
After mission is completed it must be marked as such by setting value of correct field. When carrier completes mission it's current location changes.

Your goal is to implement the logic regarding carrying out missions by carriers and fill method `CarryOutMission` in `Program.cs`.

To check distance between planets you can use method `DistanceTo` in enum `Planet`

## Requirements

**We want to be able to easily add new types of carriers with minimal to no modifications nor extensions of existing classes.**

1. Types of objects cannot be explicitly checked and compared. Use of `if`, `switch` on types and reflection mechanism is not allowed.
2. Solution must be extendable. Adding new types of missions and carriers should not require modifying already created methods.
3. You are allowed to add new fields/properties to provided classes and interfaces.
4. Modification of already created elements of classes is not allowed.