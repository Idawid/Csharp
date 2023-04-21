# Construction

Your task is to create a building material delivery system.
Each delivery consists of following elements: Material, Transporter and Equipement used to unload the material.
We want to have ability to change details of given delivery in a simple way if needed, without the need to modify the main program.

## Project contains

1. Abstract classes
	* Material, with GetMaterialType() returning MaterialType enum, and Material(double amount) constructor receiveing amount of transported material (in tons).
	* Transporter, with GetName() method returning transport type as string, Wheels being amount of wheels in transport vehicle, singleWheelLoad - maximum load of single wheel (in tons), and LoadPercentage() of whole vehicle.
	* Equipement, with GetName() returning type as string and CanApply() method.
2. Build() function receiving all classes above
3. Main function.

## Transport specification
You need to create specialized classes according to specification below.

### Budimex
1. Material: Concrete
2. Transporter: Mixer, 4 Wheels, name is "Max the Mixer", load is distributed evenly across all wheels. (material_amount)/(number_of_wheels * single_wheel_load)
3. Equipement: Pump, CanApply() returns true if material is Concrete or Asphalt, otherwise false

### Strabag

1. Material: Asphalt
2. Transporter: Cistern, 12 Wheels, name is "Clara the Cistern", load is distributed evenly across all wheels except for the first two.
3. Equipement: RoadRoller, CanApply() returns true if material is Asphalt, otherwise false

### Torpol

1. Material: Sand
2. Transporter: Truck, 8 Wheels, name is "Thomas the Truck", load is distributed evenly across all wheels although you need to add the weight of the truck (3 tons).
3. Equipement: Excavator, CanApply() returns true if material Sand, otherwise false

## Task
1. Fillout the SupplyChain method, which performs Build for multiple amounts of given material for a given company.
2. Create custom transport of 15 tons of Asphalt applied by Pump and transported with Truck


## Remarks:
1. You cannot edit existing classes and methods (except Main function)
2. You can create new classes and interfaces
3. Cannot use switch or dictionaries