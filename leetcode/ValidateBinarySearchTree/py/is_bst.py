import sys

class TreeNode:
    left = None
    right = None
    value = 0

    def __init__(self, value):
        self.value = value

    def setLeft(self, treeNode):
        self.left = treeNode

    def setRight(self, treeNode):
        self.right = treeNode


# TreeUtils

class TreeUtil:
    def isBST(self, tree):
        if tree == None:
            return True
        return self.__isValid(tree, -sys.maxsize -1, sys.maxsize)

    def __isValid(self, tree, min, max):
        if not tree:
            return True
        if tree.value >= min and tree.value <= max:
            return self.__isValid(tree.left, min, tree.value) and self.__isValid(tree.right, tree.value, max)
        else:
            return False

# Test

tree = TreeNode(5)

tree.left = TreeNode(3)
tree.left.left = TreeNode(2)
tree.left.right = TreeNode(4)

tree.right = TreeNode(9)
tree.right.left = TreeNode(7)
tree.right.right = TreeNode(11)

util = TreeUtil()
print("Valid: ? %s" %util.isBST(tree))
