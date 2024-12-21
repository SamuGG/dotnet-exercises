using DesignPatterns.Factory.BasicImplementation.Creators;
using DesignPatterns.Factory.BasicImplementation.Products;
using DesignPatterns.Factory.ExampleImplementation.Levels;

Creator creator = new ConcreteCreator();
Product product = creator.CreateProduct();

// ---

Level level1 = new CaveLevel();
level1.EncounterEnemy();

Level level2 = new HauntedHouseLevel();
level2.EncounterEnemy();
