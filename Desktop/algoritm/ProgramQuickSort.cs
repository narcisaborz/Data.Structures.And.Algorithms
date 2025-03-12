using System;

namespace SupportCases
{
    enum PriorityLevel
    {
        Critical,
        Important,
        Medium,
        Low
    }

    struct SupportTicket
    {
        public long Id;
        public string Description;
        public PriorityLevel Priority;

        public SupportTicket(long id, string description, PriorityLevel priority)
        {
            this.Id = id;
            this.Description = description;
            this.Priority = priority;
        }
    }

    class Program
    {
        static void Main()
        {
            SupportTicket[] tickets = ReadSupportTickets();
            Quick3Sort(tickets, 0, tickets.Length - 1);
            Print(tickets);
            Console.Read();
        }

        static void Quick3Sort(SupportTicket[] tickets, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int lt = low;
            int i = low + 1;
            int gt = high;
            PriorityLevel pivot = tickets[low].Priority;

            while (i <= gt)
            {
                if (tickets[i].Priority < pivot)
                {
                    Swap(ref tickets[lt], ref tickets[i]);
                    lt++;
                    i++;
                }
                else if (tickets[i].Priority > pivot)
                {
                    Swap(ref tickets[i], ref tickets[gt]);
                    gt--;
                }
                else
                {
                    i++;
                }
            }

            Quick3Sort(tickets, low, lt - 1);
            Quick3Sort(tickets, gt + 1, high);
        }

        static void Swap(ref SupportTicket a, ref SupportTicket b)
        {
            SupportTicket temp = a;
            a = b;
            b = temp;
        }

        static void Print(SupportTicket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                Console.WriteLine(tickets[i].Id + " - " + tickets[i].Description + " - " + tickets[i].Priority);
            }
        }

        static SupportTicket[] ReadSupportTickets()
        {
            const int ticketIdIndex = 0;
            const int descriptionIndex = 1;
            const int priorityLevelIndex = 2;

            int ticketsNumber = Convert.ToInt32(Console.ReadLine());
            SupportTicket[] result = new SupportTicket[ticketsNumber];

            for (int i = 0; i < ticketsNumber; i++)
            {
                string[] ticketData = Console.ReadLine().Split('-');
                long id = Convert.ToInt64(ticketData[ticketIdIndex]);
                result[i] = new SupportTicket(id, ticketData[descriptionIndex].Trim(), GetPriorityLevel(ticketData[priorityLevelIndex]));
            }

            return result;
        }

        static PriorityLevel GetPriorityLevel(string priority)
        {
            return priority.ToLower().Trim() switch
            {
                "critical" => PriorityLevel.Critical,
                "important" => PriorityLevel.Important,
                "medium" => PriorityLevel.Medium,
                _ => PriorityLevel.Low,
            };
        }
    }
}
