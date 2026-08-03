class Solution:
    def stoneGameIII(self, stoneValue: List[int]) -> str:
        # n = len(stoneValue)
        # diff = [0]*(n+2)
        # diff[-3] = stoneValue[-1]

        # for i in range(n-2, -1, -1):
        #     diff[i] = max(sum(stoneValue[i:i+x+1])-diff[i+x+1] for x in range(3))
        # if diff[0] > 0:
        #     return "Alice"
        # if diff[0] < 0:
        #     return "Bob"
        # if diff[0] == 0:
        #     return "Tie"
        
        s1, s2, s3 = 0, 0, 0
        tot = 0

        for value in reversed(stoneValue):
            tot += value
            s1, s2, s3 = tot-min(s1,s2,s3),s1,s2
        bob = tot - s1
        if s1 > bob:
            return "Alice"
        if s1 < bob:
            return "Bob"
        if s1 == bob:
            return "Tie"
        