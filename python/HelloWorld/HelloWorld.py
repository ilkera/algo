# Print to COnsole
print("hello this is my first line")

# Sum two numbers
firstNum = 3
secondNum = 4
sum = firstNum + secondNum
print(sum)

# string concatenation
strOne = "Hello"
strTwo = "World"
strConcat = strOne + " " + strTwo
print(strConcat)

# assignments
a, b = 3, 4
print(a)
print(b)

# lists
print("Working with lists")
myList = []
myList.append(1)
myList.append(2)
myList.append(3)

for value in myList:
    print(value)

secondList = [1, 2, 3]
print("Second list")
for value in secondList:
    print(value)

names = ["John", "Jennifer", "Bill"]
print("names are;")

for name in names:
    print(name)

# Basic operators

# ** denotes power relationship
squared = 2 ** 2
cubed = 3 ** 3
print(squared)
print(cubed)

# string operators
firstStr = "hello"
secondStr = "world"
thirdStr = firstStr + " " + secondStr
print(thirdStr)

# supports multiplying strings
lotsOfHellos = firstStr * 10
print(lotsOfHellos)

# operators with lists
print("+ operator with lists (join)")
evenNumbers = [2, 4, 6]
oddNumbers = [1, 3, 5]
allNumbers = evenNumbers + oddNumbers

for number in allNumbers:
    print(number)

print("Allnumbers array contains %d items" % len(allNumbers))

# string formatting
# argument specifiers
name = "ilker"
print("Hello %s!" % name)
age = 27
print("%s is %d years old!" % (name, age))

# printing lists
print("Even numbers: %s" % evenNumbers)

# printing float numbers
balance = 50.42
print("Hi %s your balance is: %.2f$" %(name, balance))

# Basic string operations
basicStr = "Hello world!"
print("Len of string: %d" %len(basicStr))
print("Index of o is: %d" %basicStr.index("o"))
print("Number of l character: %d" % basicStr.count("l"))
print("Substring from 1,5: %s" %basicStr[1:5])
print("Upper: %s Lower: %s" %(basicStr.upper(), basicStr.lower()))
print("Does string starts with 'Hello' ? : %s" % basicStr.startswith("Hello"))
print("Does string ends with 'abc'? : %s" % (basicStr.endswith("abc")))

citiesStr = "Ankara Istanbul Paris London"
cities = citiesStr.split(" ")
print("Cities: %s" %cities)

# Conditionals
x = 2
print("x == 2 ? %s" % (x == 2))

# Boolean operators and & or
name = "ilker"
age = 27

if name == "ilker" and age == 27: # and operator
    print("Your name is %s and age: %d" %(name, age))

if name == "ilker" or name == "John": # or operator
    print("Your name is either %s or %s" %("John","ilker"))

if name in ["ilker", "John"]: # check existence like SQL in
     print("Your name is either %s or %s" %("John","ilker"))

# if-elif-else
number = 4
if number in evenNumbers:
    print("Number %d is even number" % number)
elif number in oddNumbers:
    print("Number %d is odd number" % number)
else:
    print("Number %d doesn't exist in the list" %number)

# is operator - checks if the instances are same, unlike == which checks the values
x = [1, 2, 3]
y = [1, 2, 3]

print("x == y: %s" %(x == y))
print("x is y: %s" %(x is y))

# not operator (same as ! operator in C#)
x = 5

if not x == 4:
    print("x is not equal to 4")
else:
    print("x is equal to 4")

# Some examples of objects which are considered as empty
# A statement is evaluated true if the object is not empty
emptyStr = ""
emptyList = []
emptyNumber = 0
emptyBool = False

if not emptyStr:
    print("Empty string")

if not emptyList:
    print("Empty list")

if not emptyNumber:
    print("Number 0")

if not emptyBool:
    print("False")

# Loops

# For loop
print("For loop example with primes")
primes = [2, 3, 5, 7]
for prime in primes:
    print(prime)

# range
print("Numbers from 0(inclusive) to 5 (exclusive)")
for number in range(5):
    print(number)

print("Numbers from 3(inclusive) to 6 (exclusive)")
for number in range(3,6):
    print(number)

# while loop
print("WHile loop")
count = 0
while count < 5:
    print(count)
    count += 1

# break and continue
print("Break and continue")
primes = [2, 3, 5, 7, 11, 13, 17]
print("Print odd prime numbers less than 13")
for prime in primes:
    if prime == 2:
        continue
    elif prime < 13:
        print(prime)
    else:
        break

# Functions

# Basic function with no arguments
def sayHello():
    print("Hello")

sayHello()

# Basic function with arguments
def sayHelloWithName(name, greeting):
    print("Hello %s!, %s" %(name, greeting))

sayHelloWithName("ilker", "Welcome to World")

# Basic function with return value
def sum(num1, num2):
    return num1 + num2

num1 = 4
num2 = 3
print("Sum of %d and %d is %d " %(num1, num2, sum(num1, num2)))

# Classes and Objects

# Basic class
class MyClass:
    variable = "Foo"

    def myFunction(self):
        print("Bar")

# Create instance
print("Simple class instance")
myObject = MyClass()

print("Accessing my function")
myObject.myFunction()

print("Accessing variable")
print(myObject.variable)

myObject.variable = "Changed Foo"
print("New variable value: %s" %myObject.variable)

# Dictionaries

phonebook = {}
phonebook["ilker"] = 123454
phonebook["john"] = 563437
phonebook["jenny"] = 231458

# city codes
cityCodes = {
    "Ankara" : "06",
    "Istanbul" : "34",
    "Trabzon" : "61"
}

print("City codes %s" %cityCodes)

# iterating over dictionaries
for city, code in cityCodes.items():
    print("City: %s Code: %s" %(city, code))

# Removing a value - use del or pop()
del cityCodes["Trabzon"]
cityCodes.pop("Ankara")
print("After removal - City codes %s" %cityCodes)

# Add a value
cityCodes["Zonguldak"] = "67"
print("After Add - City codes %s" %cityCodes)


