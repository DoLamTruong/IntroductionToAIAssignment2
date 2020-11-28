import math
import random

def distance( pos1, pos2):
    return math.sqrt((pos1[0]-pos2[0]*1.0)**2 + (pos1[1]-pos2[1])**2)
def fitness(DNAtoCalculate, numTraveler):
    f = [fitnessEachTraveler(DNAtoCalculate.chromosome[0:DNAtoCalculate.splitTravel[0]])]
    for i in range(numTraveler-2):
        f += [fitnessEachTraveler(DNAtoCalculate.chromosome[DNAtoCalculate.splitTravel[i]:DNAtoCalculate.splitTravel[i+1]])]
    f += [fitnessEachTraveler(DNAtoCalculate.chromosome[DNAtoCalculate.splitTravel[-1]:])]
    res = 0
    for i in range(numTraveler):
        for j in range(numTraveler):
            res += abs(f[i]-f[j])
    return res

def fitnessEachTraveler( iTem):
    # doanh thu
    doanhthu = 0
    for i in range(len(iTem)):
        doanhthu += (5 + listItem[iTem[i]][1]+ 2*listItem[iTem[i]][2])
        print(listItem[iTem[i]], iTem[i])
    # Chi phi
    quangduong = distance(depart, listItem[iTem[0]][0])
    for i in range(len(iTem) - 1):
        quangduong += distance(listItem[iTem[i]][0], listItem[iTem[i+1]][0])
    chiphi = quangduong/40.0*20+10
    f = doanhthu - chiphi
    print(f, "======================================")
    return f

class DNA:
    def __init__ (self, chromosome, splitTravel):
        self.chromosome = chromosome[:]
        self.splitTravel = splitTravel[:]     

def filterInput(file_input):
    inf = open(file_input, "r")
    inf = inf.read().split('\n')
    pos = list(map(lambda x: eval(x), inf[0].split(' ')))
    soDonHang = eval(inf[1].split(' ')[1])
    soNhanVien = eval(inf[1].split(' ')[0])
    listItem = []
    temp = []
    for i in range(soDonHang):
        temp = [eval(x) for x in inf[2+i].split(' ')]
        temp[1] = temp[0:2]
        temp.pop(0)
        listItem += [temp]
    # print(listItem)
    return pos,soDonHang,soNhanVien,listItem

def writeOut(listRes, file_output):
    ResString = ""
    for i in listRes:
        ResString += str(i[0]) + ' '
        for j in i[1:-1]:
            ResString += str(j) + ' '
        if len(i) > 1:
            ResString += str(i[-1])
        ResString += '\n'
    with open(file_output, 'w') as f:
        f.write(ResString)
    return

def assign(file_input, file_output):
    # read input
    
    # run algorithm
    DNAtoCalculate = DNA([0,2,4,3,1], [1,3])
    res = fitness(DNAtoCalculate, soNhanVien)
    print(res, DNAtoCalculate.chromosome, DNAtoCalculate.splitTravel)
    # write output
    # writeOut(res, file_output)
    # return
depart, soDonHang, soNhanVien, listItem = filterInput('input.txt')

assign('input.txt', 'output1.txt')

# def main():
#     print(random.randint(0,30), random.randint(0,30))
#     print(40, 15)
#     for i in range(15):
#         print(random.randint(0,30), random.randint(0,30), random.randint(0,30), random.randint(0,30))


# main()