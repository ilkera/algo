def intersect_v2(firstList, secondList):
    intersects = []
    if not firstList or not secondList:
        return intersects

    seenNumbers = {}
    smallList, bigList = None, None

    if len(firstList) < len(secondList):
        smallList, bigList = firstList, secondList
    else:
        smallList, bigList = secondList, firstList

    for number in smallList:
        if number in seenNumbers:
            seenNumbers[number] += 1
        else:
            seenNumbers[number] = 1

    for number in bigList:
        if number in seenNumbers and seenNumbers[number] > 0:
            intersects.append(number)
            seenNumbers[number] -= 1
    return intersects

def intersect(firstArray, secondArray):
    intersects = []
    if not firstArray or not secondArray:
        return intersects

    firstArray.sort()
    secondArray.sort()

    iFirst, iSecond = 0, 0
    while iFirst < len(firstArray) and iSecond < len(secondArray):
        if firstArray[iFirst] == secondArray[iSecond]:
            intersects.append(firstArray[iFirst])
            iFirst += 1
            iSecond += 1
        elif firstArray[iFirst] < secondArray[iSecond]:
            iFirst += 1
        else:
            iSecond += 1

    return intersects

# Test client
array1 = [3, 1, 3, 6, 1, 6, 1]
array2 = [11, 8, 6, 3, 14, 1, 3]

print("%s " %array1)
print("%s " %array2)

intersectList = intersect_v2(array1, array2)
print("Intersection %s " %intersectList)