//static method in a class
//A static method is called on the class itself, not on instances of the class.
class Foo {
  static M() {
    return "Hello";
  }
}

console.log(Foo.M());
