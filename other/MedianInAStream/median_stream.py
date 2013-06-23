# Find median from a stream of numbers
import heapq

class MinHeap:
    count = 0
    heap = []

    def push(self, item):
        heapq.heappush(self.heap, item)
        self.count += 1

    def pop(self):
        if self.count == 0:
            raise Exception('No items is available')
        popped = heapq.heappop(self.heap)
        self.count -= 1
        return popped

    def min(self):
        if self.count == 0:
            raise Exception('No items is available')
        return self.heap[0]

class MaxHeap:
    count = 0
    heap = []

    def push(self, item):
        heapq.heappush(self.heap, -1 * item)
        self.count += 1

    def pop(self):
        if self.count == 0:
            raise Exception('No items is available')
        popped = heapq.heappop(self.heap) * -1
        self.count -= 1
        return popped

    def max(self):
        if self.count == 0:
            raise Exception('No items is available')
        return self.heap[0]  * -1

class MedianStream:

    count = 0
    min_heap = MinHeap()
    max_heap = MaxHeap()

    def count(self):
        return self.min_heap.count + self.max_heap.count

    def getMedian(self):
        if self.count == 0:
            raise Exception('No item is available')

        if self.count() % 2 == 0:
            return (self.min_heap.min() + self.max_heap.max()) / 2
        else:
            return self.min_heap.min()

    def insert(self, item):
        if self.count() % 2 == 0: # insert into min heap
            if self.max_heap.count > 0 and item <  self.max_heap.max():
                self.max_heap.push(item)
                item = self.max_heap.pop()
            self.min_heap.push(item)
        else:
            if self.min_heap.count > 0 and item > self.min_heap.min():
                self.min_heap.push(item)
                item = self.min_heap.pop()
            self.max_heap.push(item)

# Client and Tests #

medianFinder = MedianStream()
medianFinder.insert(5)
medianFinder.insert(10)
print("Median of %d items is %d" %(medianFinder.count(),medianFinder.getMedian()))

medianFinder.insert(3)
print("Median of %d items is %d" %(medianFinder.count(),medianFinder.getMedian()))
