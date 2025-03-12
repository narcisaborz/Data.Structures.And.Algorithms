using System;

namespace RunningContest
{
    struct Contestant
    {
        public string Name;
        public string Country;
        public double Time;

        public Contestant(string name, string country, double time)
        {
            this.Name = name;
            this.Country = country;
            this.Time = time;
        }
    }

    struct ContestRanking
    {
        public Contestant[] Contestants;
    }

    struct Contest
    {
        public ContestRanking[] Series;
        public ContestRanking GeneralRanking;
    }

    class Program
    {
        static void Main()
        {
            Contest contest = ReadContestSeries();
            GenerateGeneralRanking(ref contest);
            Print(contest.GeneralRanking);
            Console.Read();
        }

        private static void Print(ContestRanking contestRanking)
        {
            for (int i = 0; i < contestRanking.Contestants.Length; i++)
            {
                Contestant contestant = contestRanking.Contestants[i];
                const string line = "{0} - {1} - {2:F3}";
                Console.WriteLine(string.Format(line, contestant.Name, contestant.Country, contestant.Time));
            }
        }

        static void GenerateGeneralRanking(ref Contest contest)
        {
            int totalContestants = 0;
            foreach (var series in contest.Series)
            {
                totalContestants = totalContestants + series.Contestants.Length;
            }

            Contestant[] allContestants = new Contestant[totalContestants];
            int index = 0;

            foreach (var series in contest.Series)
            {
                foreach (var contestant in series.Contestants)
                {
                    allContestants[index++] = contestant;
                }
            }

            MergeSort(allContestants, 0, allContestants.Length - 1);

            contest.GeneralRanking = new ContestRanking { Contestants = allContestants };
        }

        static void MergeSort(Contestant[] array, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            int m = l + (r - l) / 2;
            MergeSort(array, l, m);
            MergeSort(array, m + 1, r);
            Merge(array, l, m, r);
        }

        static void Merge(Contestant[] array, int l, int m, int r)
        {
            int lf = m - l + 1;
            int ri = r - m;

            Contestant[] left = new Contestant[lf];
            Contestant[] right = new Contestant[ri];

            for (int i = 0; i < lf; i++)
            {
                left[i] = array[l + i];
            }

            for (int j = 0; j < ri; j++)
            {
                right[j] = array[m + 1 + j];
            }

            int indexI = 0;
            int indexJ = 0;
            int k = l;

            while (indexI < lf && indexJ < ri)
            {
                if (left[indexI].Time <= right[indexJ].Time)
                {
                    array[k] = left[indexI];
                    indexI++;
                }
                else
                {
                    array[k] = right[indexJ];
                    indexJ++;
                }

                k++;
            }

            while (indexI < lf)
            {
                array[k] = left[indexI];
                indexI++;
                k++;
            }

            while (indexJ < ri)
            {
                array[k] = right[indexJ];
                indexJ++;
                k++;
            }
        }

        static Contest ReadContestSeries()
            {
                Contest contest = new Contest();

                int seriesNumber = Convert.ToInt32(Console.ReadLine());
                int contestantsPerSeries = Convert.ToInt32(Console.ReadLine());

                contest.Series = new ContestRanking[seriesNumber];

                for (int i = 0; i < seriesNumber; i++)
                {
                    contest.Series[i].Contestants = new Contestant[contestantsPerSeries];
                    for (int j = 0; j < contestantsPerSeries; j++)
                    {
                        string contestantLine = "";

                        while (contestantLine == "")
                        {
                            contestantLine = Console.ReadLine();
                        }

                        contest.Series[i].Contestants[j] = CreateContestant(contestantLine.Split('-'));
                    }
                }

                return contest;
            }

        private static Contestant CreateContestant(string[] contestantData)
            {
                const int nameIndex = 0;
                const int countryIndex = 1;
                const int timeIndex = 2;

                return new Contestant(
                    contestantData[nameIndex].Trim(),
                    contestantData[countryIndex].Trim(),
                    Convert.ToDouble(contestantData[timeIndex]));
            }
        }
    }
