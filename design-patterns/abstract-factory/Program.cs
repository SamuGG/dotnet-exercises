using DesignPatterns.AbstractFactory.BasicImplementation.Factories;
using DesignPatterns.AbstractFactory.BasicImplementation.Products;
using DesignPatterns.AbstractFactory.ExampleImplementation.CaveLevel;
using DesignPatterns.AbstractFactory.ExampleImplementation.Common;
using DesignPatterns.AbstractFactory.ExampleImplementation.HauntedHouseLevel;

AbstractFactory abstractFactory = new ConcreteFactory();
Product1 product1 = abstractFactory.CreateProduct1();
Product2 product2 = abstractFactory.CreateProduct2();

// ---

LevelElementFactory caveLevelFactory = new CaveLevelElementFactory();
caveLevelFactory.SetupGameEnvironment();

LevelElementFactory hauntedHouseLevelFactory = new HauntedHouseLevelElementFactory();
hauntedHouseLevelFactory.SetupGameEnvironment();