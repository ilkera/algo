# Simple Stack implementation using array
class Stack:
    capacity = 0
    array = []

    def __init__(self, capacity):
        self.capacity = capacity

    # push item to stack
    def push(self, item):
        if self.isFull():
            raise Exception('Stack is full')
        self.array.append(item)

    # pop item from stack
    def pop(self):
        if self.isEmpty():
            raise Exception('Stack is empty')
        top = self.array[-1]
        del self.array[-1]
        return top

    # return peek item
    def peek(self):
        if self.isEmpty():
            raise Exception('Stack is empty')
        peek = self.array[-1]
        return peek

    # returns true if stack is empty
    def isEmpty(self):
        return len(self.array) == 0

    # returns true if stack is full
    def isFull(self):
        return len(self.array) == self.capacity

    # returns the number of items in the stack
    def count(self):
        return len(self.array)

    # clears all items
    def clear(self):
        self.array.clear()

# Tests
def testIsStackEmpty():
    stack = Stack(5)
    assert stack.isEmpty() == True , "Stack is not empty"

def testStackCount():
    stack = Stack(3)
    assert stack.count() == 0
    stack.push(1)
    assert stack.count() == 1
    stack.push(2)
    stack.push(3)
    assert stack.count() == 3
    stack.clear()

def testIsStackFull():
    stack = Stack(1)
    stack.push(1)
    assert stack.isFull() == True, "Stack is not full"
    stack.clear()

def testPushItem():
    stack = Stack(3)
    assert stack.isEmpty() == True, "Stack is not empty"
    stack.push(1)
    assert stack.count() == 1, "Stack count doesn't match. Expected: 1 Actual: %d" %stack.count()
    assert stack.peek() == 1, "Last inserted item doesn't match with peek"
    stack.push(2)
    assert stack.count() == 2, "Stack count doesn't match. Expected: 2 Actual: %d" %stack.count()
    assert stack.peek() == 2, "Last inserted item doesn't match with peek"
    stack.clear()

def testPushedItemPoppedBack():
    stack = Stack(3)
    stack.push(1)
    stack.push(2)
    top = stack.pop()
    assert top == 2, "Last inserted item is not popped"
    assert stack.count() == 1, "Number of items in stack is not right. Expected: 1 Actual: %r" %stack.count()
    stack.clear()

def testPoppedItemRemoved():
    stack = Stack(3)
    stack.push(1)
    stack.push(2)
    popped = stack.pop()
    assert stack.count() == 1, "Stack count doesn't match with expected. Expected: 1 Actual: %d" %stack.count()
    popped = stack.pop()
    assert stack.count() == 0 , "Stack is not empty"
    stack.clear()

def testPeekItem():
    stack = Stack(3)
    stack.push(1)
    stack.push(2)
    stack.push(3)
    peek = stack.peek()
    assert peek == 3, "Peek element doesn't match with expected. Expected: 3, Actual: %d" %peek
    stack.clear()

def testPeekItemNotRemoved():
    stack = Stack(3)
    stack.push(1)
    stack.push(2)
    stack.push(3)
    peek = stack.peek()
    assert stack.count() == 3, "Stack count should not change"
    assert peek == 3, "Peek item is 3"
    peek = stack.peek()
    assert peek == 3, "Peek item is removed"
    stack.clear()

def testClearStack():
    stack = Stack(3)
    stack.push(1)
    stack.push(2)
    stack.push(3)
    stack.clear()
    assert stack.count() == 0, "Stack is not cleared"

def testPushNotAllowedOnFull():
   stack = Stack(3)
   stack.push(1)
   stack.push(2)
   stack.push(3)
   try:
        stack.push(4)
   except Exception as ex:
       assert ex.args[0] == "Stack is full"
   stack.clear()

def testPopNotAllowedOnEmpty():
    stack = Stack(1)
    stack.push(1)
    stack.pop()

    try:
        stack.pop()
    except Exception as ex:
        assert  ex.args[0] == "Stack is empty"
    stack.clear()

def testPeekNotAllowedOnEmpty():
    stack = Stack(1)
    stack.push(1)
    stack.pop()

    try:
        stack.peek()
    except Exception as ex:
        assert  ex.args[0] == "Stack is empty"
    stack.clear()

def testReverseOrder():
    stack = Stack(5)
    stack.push(1)
    stack.push(2)
    stack.push(3)
    stack.push(4)
    stack.push(5)

    assert stack.pop() == 5
    assert stack.pop() == 4
    assert stack.pop() == 3
    assert stack.pop() == 2
    assert stack.pop() == 1

# Client #

# Test Empty
testIsStackEmpty()

# Test Full
testIsStackFull()

# Test Stack count
testStackCount()

# Test Push
testPushItem()
testPushNotAllowedOnFull()

# Test Pop
testPushedItemPoppedBack()
testPoppedItemRemoved()
testPopNotAllowedOnEmpty()

# Reverse Order
testReverseOrder()

# Tesk peek item
testPeekItem()
testPeekItemNotRemoved()
testPeekNotAllowedOnEmpty()

# Test clear
testClearStack()