using HotelsHubApp.Business.Helper.ResponseMappping.Models;


namespace HotelsHubApp.Business.Helper.ResponseMappping
{
    static class Query
     {
        public static IEnumerable<(Room a, Room b)> JoinTwoList(params
                             IGrouping<(int rooms, int adults, int children, string childrenAges), Room>[] args)

        {
            var result = from a in args[0]
                         join b in args[1] on (a.rate.boardCode, a.rate.rateClass, a.rate.cancellationPolicies[0].@from)
                         equals (b.rate.boardCode, b.rate.rateClass, b.rate.cancellationPolicies[0].@from)
                         select (a, b);
            return result;
        }
        
        public static IEnumerable<(Room a, Room b, Room c)> JoinThreeList(params
                                IGrouping<(int rooms, int adults, int children, string childrenAges), Room>[] args)
                                
        {
             var result = from a in args[0]
                          join b in args[1] on (a.rate.boardCode, a.rate.rateClass, a.rate.cancellationPolicies[0].@from)
                          equals (b.rate.boardCode, b.rate.rateClass, b.rate.cancellationPolicies[0].@from)
                          join c in args[2] on (a.rate.boardCode, a.rate.rateClass, a.rate.cancellationPolicies[0].@from)
                          equals (c.rate.boardCode, c.rate.rateClass, c.rate.cancellationPolicies[0].@from)
                          select (a, b, c);
             return result;
        }
       
        public static IEnumerable<(Room a, Room b, Room c,Room d)> JoinFourList(params
                               IGrouping<(int rooms, int adults, int children, string childrenAges), Room>[] args)
                       
        {
              var result = from a in args[0]
                           join b in args[1] on (a.rate.boardCode, a.rate.rateClass, a.rate.cancellationPolicies[0].@from)
                           equals (b.rate.boardCode, b.rate.rateClass, b.rate.cancellationPolicies[0].@from)
                           join c in args[2] on (a.rate.boardCode, a.rate.rateClass, a.rate.cancellationPolicies[0].@from)
                           equals (c.rate.boardCode, c.rate.rateClass, c.rate.cancellationPolicies[0].@from)
                           join d in args[3] on (a.rate.boardCode, a.rate.rateClass, a.rate.cancellationPolicies[0].@from)
                           equals (d.rate.boardCode, d.rate.rateClass, d.rate.cancellationPolicies[0].@from)
                           select ( a, b, c, d );
            return result;
        }

    }
}
