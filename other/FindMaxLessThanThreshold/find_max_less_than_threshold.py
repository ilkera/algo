import sys

def findMaxBelowThreshold(list, threshold):
    if not list:
        raise Exception("Empty/null")

    maxSoFar = -sys.maxsize - 1
    for value in list:
        if maxSoFar < value < threshold:
            maxSoFar = value
    return maxSoFar

# Test client
list = [8, 14, 3, 10, 16, 1, 9, 0, 4]
print(list)
# Case 1 : T == max
print(findMaxBelowThreshold(list, 16))
# Case 2 : T > max
print(findMaxBelowThreshold(list, 17))
# Case 3 : T == min
print(findMaxBelowThreshold(list, 0))
# Case 4 : T < min
print(findMaxBelowThreshold(list, -1))
# Case 5 : min < T < max
print(findMaxBelowThreshold(list, 10))

