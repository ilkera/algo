# Queue implementation using list (array)
# Notes: Use collections.deque for queue data structure and if you are using lots of pop() operation

class MyQueue:
    capacity = 0
    list = []

    def __init__(self, capacity):
        self.capacity = capacity

    # Push an item to queue
    def enqueue(self, item):
        if self.isFull():
            raise Exception('Queue is full')
        self.list.append(item)

    # Pop an item from queue
    def dequeue(self):
        if self.isEmpty():
            raise Exception('Queue is empty')
        front = self.list.pop(0)
        return front

    def front(self):
        if self.isEmpty():
            raise Exception('Queue is empty')
        front = self.list[0]
        return front

    def isEmpty(self):
        return self.count() == 0;

    def isFull(self):
        return self.count() == self.capacity

    def count(self):
        return len(self.list)

    def clear(self):
       self.list.clear()

# Tests #
def testQueueIsEmpty():
    queue = MyQueue(3)
    assert (queue.count() == 0), "Queue is not empty"

def testQueueIsFull():
    queue = MyQueue(1)
    queue.enqueue(1)
    assert (queue.isFull() == True), "Queue is not full"
    queue.clear()

def testEnqueueItem():
    queue = MyQueue(3)
    queue.enqueue(1)
    assert (queue.count() == 1)
    assert (queue.list[-1] == 1)
    queue.enqueue(2)
    assert (queue.count() == 2)
    assert (queue.list[-1] == 2)
    queue.clear()

def testDequeueItem():
    queue = MyQueue(3)
    queue.enqueue(1)
    queue.enqueue(2)
    popped = queue.dequeue()
    assert (popped == 1)
    popped = queue.dequeue()
    assert (popped == 2)

def testDequeuedItemRemoved():
    queue = MyQueue(3)
    queue.enqueue(1)
    queue.enqueue(2)
    popped = queue.dequeue()
    assert (queue.list[0] == 2)
    queue.clear()

def testQueueCount():
    queue = MyQueue(2)
    assert queue.count() == 0
    queue.enqueue(1)
    assert queue.count() == 1
    queue.enqueue(2)
    assert queue.count() == 2
    queue.clear()

def testClearQueue():
    queue = MyQueue(3)
    queue.enqueue(1)
    queue.enqueue(2)
    queue.enqueue(3)
    queue.clear()
    queue.count() == 0

# Client #

# Empty Queue
testQueueIsEmpty()

# Full Queue
testQueueIsFull()

# Enqueue item
testEnqueueItem()

# Dequeue Item
testDequeueItem()
testDequeuedItemRemoved()

# Count
testQueueCount()

# Clear
testClearQueue()