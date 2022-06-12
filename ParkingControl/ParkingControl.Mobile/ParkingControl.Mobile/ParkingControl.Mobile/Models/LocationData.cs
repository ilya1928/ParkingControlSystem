using ParkingControl.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingControl.Mobile.Models
{
    public static class LocationData
    {
        public static IList<District> Districts { get; private set; }

        static LocationData()
        {
            Districts = new List<District>();

            Districts.Add(new District
            {
                Id = Guid.Parse("97ff6030-9a4b-4d46-a945-fa02db1557ec"),
                Name = "Дніпровський",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Id = Guid.Parse("97a3929a-652d-4269-a83b-5f10b40b8512"),
                        Name = "вул. Жмаченко"
                    },
                    new Address
                    {
                        Id = Guid.Parse("8e4c113c-4e5f-4f54-89a8-5f9d85cebf35"),
                        Name = "Дарницька площа"
                    },
                    new Address
                    {
                        Id = Guid.Parse("76fdec93-7314-4d68-bac4-927a0305caa9"),
                        Name = "вул. Лобачевського"
                    },
                    new Address
                    {
                        Id = Guid.Parse("e2d8e689-2615-4780-9621-93c32ffa2fef"),
                        Name = "вул. Слобідська"
                    },
                    new Address
                    {
                        Id = Guid.Parse("10658b1a-264a-48ce-9b70-a0bd02c1d548"),
                        Name = "вул. Березняківська"
                    },
                    new Address
                    {
                        Id = Guid.Parse("02589fbb-d251-436d-99ba-a91537a71ef2"),
                        Name = "бул. Перова"
                    },
                    new Address
                    {
                        Id = Guid.Parse("97ff6030-9a4b-4d46-a945-fa02db1557ec"),
                        Name = "вул. Шептицького",
                        Locations = new List<Location>
                        {
                            new Location
                            {
                                Id = Guid.Parse("e41e211a-a7b8-4458-a844-d132212aba15"),
                                Code = "1"
                            },
                            new Location
                            {
                                Id = Guid.Parse("ba98a5ad-41c0-4096-aade-20bcd761ef00"),
                                Code = "1А"
                            },
                            new Location
                            {
                                Id = Guid.Parse("4212a50c-755f-4deb-a7a4-111eba1f7073"),
                                Code = "2"
                            },
                            new Location
                            {
                                Id = Guid.Parse("05d926f3-2172-43c4-9d46-b90606c2601a"),
                                Code = "2А"
                            },
                            new Location
                            {
                                Id = Guid.Parse("566447e1-5459-431b-b89b-879ab424e7d1"),
                                Code = "2Б"
                            },
                            new Location
                            {
                                Id = Guid.Parse("2b6819a0-f2d6-4a42-9084-7d97590a7870"),
                                Code = "3"
                            },
                            new Location
                            {
                                Id = Guid.Parse("1b021aae-f0b8-4cc3-817a-3421cc872ad4"),
                                Code = "4"
                            },
                            new Location
                            {
                                Id = Guid.Parse("e2d071e0-0424-441e-81ff-b9a78239ce6e"),
                                Code = "5"
                            },
                        }
                    },
                }
            });

            Districts.Add(new District
            {
                Id = Guid.Parse("6fa7185d-c4bb-4914-a752-172935b96e2b"),
                Name = "Голосіївський"
            });

            Districts.Add(new District
            {
                Id = Guid.Parse("aab07807-78cb-4703-b376-494ba13eb092"),
                Name = "Дарницький"
            });

            Districts.Add(new District
            {
                Id = Guid.Parse("03b2e265-8b86-43aa-a592-610e4220fbb6"),
                Name = "Солом'янський"
            });

            Districts.Add(new District
            {
                Id = Guid.Parse("f153c03d-97d7-4251-af3f-9553e1bec2f2"),
                Name = "Святошинський"
            });

            Districts.Add(new District
            {
                Id = Guid.Parse("844a339b-2751-4c17-955f-adff95957cad"),
                Name = "Оболонський"
            });

            Districts.Add(new District
            {
                Id = Guid.Parse("198c12dc-4a58-4599-a445-b372eef44305"),
                Name = "Печерський"
            });

            Districts.Add(new District
            {
                Id = Guid.Parse("0cbd1116-a168-4412-9e2d-e37f4dcad461"),
                Name = "Деснянський"
            });

            Districts.Add(new District
            {
                Id = Guid.Parse("1fb61669-4138-4122-81f9-ee882a45fd4c"),
                Name = "Подільский"
            });
        }
    }
}
