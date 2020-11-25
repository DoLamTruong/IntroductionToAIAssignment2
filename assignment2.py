# Them cac thu vien neu can
import math
import random

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

# ============================================================
# algorithm to solve the problem
# use generic algorithm

class algorithmMultiTravelUseGeneticAlgorithm:
    def __init__(self, depart, numItem, numTraveler, listItem):
        self.listItem = listItem
        self.depart = depart
        self.numItem = numItem
        self.numTraveler = numTraveler
        self.nPopulation = 25
        mutationRate = 0.05
        numLoop = 1500
        count = 0

        populationList = self.InitPopulation(numItem, numTraveler, self.nPopulation)
        
        while True:
            #  tạo mating pool
            matingPool, maxIndex = self.CreateMatingPool(populationList)
            
            # lấy 2 phần tử dựa vào mating pool
            print(matingPool)
            p1 = populationList[matingPool[random.randint(0, len(matingPool)-1)]]
            p2 = populationList[matingPool[random.randint(0, len(matingPool)-1)]]
            while p1 == p2:
                p2 = populationList[matingPool[random.randint(0, len(matingPool)-1)]]

            # ngẫu nhiên tìm điểm cắt
            splitPoint = random.randint(0,self.numItem-1)
            
            # lai tạo để tạo ra phần tử mới
            newDNA = self.crossOver(p1, p2, splitPoint)
            
            # biến dị dựa trên tỷ lệ biến dị
            self.mutate(newDNA, mutationRate)
            
            # thay thế phần tử cũ
            populationList[maxIndex] = newDNA
            
            # kiểm tra điều kiện dừng
            count += 1
            if (count > numLoop):
                break
        
        finessList = [self.fitness(x) for x in populationList]
        minFitness = min(finessList)
        minIndex = finessList.index(minFitness)
        ADNRes = populationList[minIndex]
        self.resList = ADNRes.chromosome[:ADNRes.splitTravel[0]]
        ADNRes.splitTravel += [self.numItem]
        for i in range(1, self.numItem):
            self.resList += [ADNRes.chromosome[ADNRes.splitTravel[i]:ADNRes.splitTravel[i+1]]]


    def InitPopulation(self, soDonHang, soNhanVien, nPopulation):
        res = []
        temp = [i for i in range(soDonHang)]
        for i in range(nPopulation):
            random.shuffle(temp)
            b = self.generateSplitTravel()
            res += [DNA(temp, b)]
            # print(temp, b)
        return res


    def generateSplitTravel(self):
        interval = int(self.numItem / self.numTraveler)
        randAdd = random.randint(-int(interval/2),int(interval/2))
        res = []
        for i in range(1, self.numTraveler):
            res.append(interval*i + randAdd)
        return res


    def CreateMatingPool(self, populationList):
        finessList = [self.fitness(x) for x in populationList]
        maxFitness = max(finessList)
        maxIndex = finessList.index(maxFitness)
        res = []
        for i in range(self.nPopulation):
            for loop in range(int((maxFitness-finessList[i])/maxFitness*25)):
                res += [i]
        return res, maxIndex



    def distance(self, pos1, pos2):
        return math.sqrt((pos1[0]-pos2[0])**2 + (pos1[1]-pos2[1])**2)

    def fitness(self, DNAtoCalculate):
        f = [self.fitnessEachTraveler(DNAtoCalculate.chromosome[0:DNAtoCalculate.splitTravel[0]])]
        for i in range(self.numTraveler-2):
            f += [self.fitnessEachTraveler(DNAtoCalculate.chromosome[DNAtoCalculate.splitTravel[i]:DNAtoCalculate.splitTravel[i+1]])]
        f += [self.fitnessEachTraveler(DNAtoCalculate.chromosome[DNAtoCalculate.splitTravel[-1]:])]
        res = 0
        for i in range(self.numTraveler):
            for j in range(self.numTraveler):
                res += abs(f[i]-f[j])
        return res

    def fitnessEachTraveler(self, iTem):
        res = (5 + self.listItem[iTem[0]][1]+ 2*self.listItem[iTem[0]][2]) - (self.distance(self.depart, self.listItem[iTem[0]][0])/40*20+10)
        for i in range(len(iTem) - 1):
            res += (5 + self.listItem[iTem[i+1]][1]+ 2*self.listItem[iTem[i+1]][2]) - (self.distance(self.listItem[iTem[i]][0], self.listItem[iTem[i+1]][0])/40*20+10)
        return res

    def crossOver(self, p1, p2, splitPoint):
        chro1 = p1.chromosome[:]
        chro2 = p2.chromosome[:]
        res = []
        pA = chro1.index(splitPoint)
        pB = chro2.index(splitPoint)
        while chro1:
            res += [splitPoint]
            chro1.remove(splitPoint)
            chro2.remove(splitPoint)
            if not chro1:
                break
            pA = pA%(len(chro1))
            pB = pB%(len(chro2))
            if (self.distance(self.listItem[splitPoint][0], self.listItem[chro1[pB]][0]) > self.distance(self.listItem[splitPoint][0], self.listItem[chro1[pA]][0])):
                splitPoint = chro2[pB]
            else:
                splitPoint = chro1[pA]
        
        splitTravel = p1.splitTravel[:]
        newDNA = DNA(res, splitTravel)
        updateSplit = random.randint(0,self.numTraveler-2)

        minNewDNAFitness = self.fitness(newDNA)
        minValue = splitTravel[updateSplit]

        if updateSplit >0:
            begin = splitTravel[updateSplit-1] + 2
        else:
            begin = 1
        if updateSplit < self.numTraveler-2:
            end = splitTravel[updateSplit+1] -2
        else:
            end = self.numItem -1
        
        for i in range(begin, end+1):
            newDNA.splitTravel[updateSplit] = i
            if minNewDNAFitness > self.fitness(newDNA):
                minValue = i
                minNewDNAFitness = self.fitness(newDNA)
        newDNA.splitTravel[updateSplit] = minValue
        return newDNA





    def mutate(self, newDNA, mutationRate):
        if random.random() < mutationRate:
            tempChro = newDNA.chromosome
            begin = random.randint(0, self.numItem -2)
            end = random.randint(begin+1, self.numItem -1)
            tempChro[begin:end] = reversed(tempChro[begin:end])
            newDNA.splitTravel = self.generateSplitTravel()

    def result(self):
        return self.resList

class DNA:
    def __init__ (self, chromosome, splitTravel):
        self.chromosome = chromosome[:]
        self.splitTravel = splitTravel[:]     

    
# ============================================================
# Write output to file

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

# ============================================================
def assign(file_input, file_output):
    # read input
    pos, soDonHang, soNhanVien, listItem = filterInput(file_input)
    # run algorithm
    res = algorithmMultiTravelUseGeneticAlgorithm(pos,soDonHang, soNhanVien,listItem)
    print(res.result())
    # write output
    # writeOut(res, file_output)
    return


assign('input.txt', 'output.txt')
