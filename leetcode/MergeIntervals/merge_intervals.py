"""

Problem: Merge Intervals
Given a collection of intervals, merge all overlapping intervals.

For example,
Given [1,3],[2,6],[8,10],[15,18],
return [1,6],[8,10],[15,18].
"""

class Interval:
    start = 0
    end = 0

    def __init__(self, start, end):
        self.start = start
        self.end = end

def mergeIntervals_v2(intervals): # without using Interval class
    merged = []
    if not intervals:
        return merged

    # Sort intervals (start, end) by first key which is start
    intervals.sort(key = lambda tup: tup[0])

    currentInterval = ()
    start, end = 0, 0

    for interval in intervals:
        if not currentInterval:
            currentInterval = interval
        elif interval[0] <= currentInterval[1] and currentInterval[0] <= interval[1]:
            start = currentInterval[0] if currentInterval[0] < interval[0] else interval[0]
            end = currentInterval[1] if currentInterval[1] > interval[1] else interval[1]
        else:
           if not start and not end:
               merged.append((currentInterval[0], currentInterval[1]))
           else:
                merged.append((start, end))
           currentInterval = interval
           start, end = 0, 0

    if not start and not end:
        merged.append((currentInterval[0], currentInterval[1]))
    else:
        merged.append((start, end))
    return merged

def mergeIntervals(intervals):
    merged = []
    if not intervals:
        return merged

    # Sort intervals (start, end) by first key which is start
    intervals.sort(key = lambda tup: tup[0])

    currentInterval = None
    for interval in intervals:
       if not currentInterval:
           currentInterval = Interval(interval[0], interval[1])
       elif interval[0] <= currentInterval.end and currentInterval.start <= interval[1]:
           currentInterval.start = currentInterval.start if currentInterval.start < interval[0] else interval[0]
           currentInterval.end = currentInterval.end if currentInterval.end > interval[1] else interval[1]
       else:
           merged.append(currentInterval)
           currentInterval = Interval(interval[0], interval[1])
    merged.append(currentInterval)
    return merged


# Test
intervals = [(12, 21),(1,3), (2,6), (8,10), (15,18)]
print("Initial Intervals %s" %intervals)

mergedV2 = mergeIntervals_v2(intervals)
print("Merged Intervals v2 %s" %mergedV2)

merged = mergeIntervals(intervals)
for interval in merged:
    print("(%d,%d)" %(interval.start, interval.end))