﻿using CollectionViewPerformance.Models;
using System.Collections.Generic;

namespace CollectionViewPerformance.Services
{
    public class MonkeyService
    {
        public static List<Monkey> GetMonkeys()
        {
            List<Monkey> monkeys = new List<Monkey>();

            for (int i = 0; i < AppSettings.TotalMonkeys / 5; i++)
            {
                monkeys.Add(new Monkey
                {
                    Name = "Baboon",
                    Location = "Africa & Asia",
                    Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                    Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
                });

                monkeys.Add(new Monkey
                {
                    Name = "Capuchin Monkey",
                    Location = "Central & South America",
                    Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                    Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
                });

                monkeys.Add(new Monkey
                {
                    Name = "Blue Monkey",
                    Location = "Central and East Africa",
                    Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
                    Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"
                });

                monkeys.Add(new Monkey
                {
                    Name = "Squirrel Monkey",
                    Location = "Central & South America",
                    Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
                    Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg"
                });

                monkeys.Add(new Monkey
                {
                    Name = "Golden Lion Tamarin",
                    Location = "Brazil",
                    Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
                    Image = "http://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg"
                });
            }

            return monkeys;
        }
    }
}