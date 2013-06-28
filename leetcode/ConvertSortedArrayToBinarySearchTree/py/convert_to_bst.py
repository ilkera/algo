from _collections import deque

# define Tree
class Tree:
    left = None
    right = None
    value = 0

    def __init__(self, value, left = None, right = None):
        self.value = value
        self.left = left
        self.right = right

class TreeUtil:
    def preOrder(self, tree):
        if not tree:
            return

        print(tree.value)
        self.preOrder(tree.left)
        self.preOrder(tree.right)

    def levelOrder(self, tree):
        if not tree:
            return

        queue = deque()
        queue.append(tree)
        currentLevel, nextLevel = 1, 0

        while len(queue) != 0:
            current = queue.popleft()
            print(current.value, end = ' ')
            currentLevel -= 1

            if current.left:
                queue.append(current.left)
                nextLevel += 1
            if current.right:
                queue.append(current.right)
                nextLevel += 1
            if currentLevel == 0:
                print("")
                currentLevel = nextLevel
                nextLevel = 0

    def __constructTree(self, array, start, end):
        if start > end:
            return None
        if start == end:
            return Tree(array[start])

        mid = int(start + (end - start) / 2)
        tree = Tree(array[mid])
        tree.left = self.__constructTree(array, start, mid - 1)
        tree.right = self.__constructTree(array, mid + 1, end)
        return tree

    def convertToBST(self, sortedArray):
        if not sortedArray:
            print("Empty/null array")

        tree = self.__constructTree(sortedArray, 0, len(sortedArray) - 1)
        return tree

# Test Client #
array = [1, 2, 3, 4, 5, 6, 7, 8]
util = TreeUtil()
tree = util.convertToBST(array)
util.levelOrder(tree)
