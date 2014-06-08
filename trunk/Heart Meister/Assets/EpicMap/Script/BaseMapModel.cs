using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonGenerator
{
    public class BaseMapModel
    {
        private static readonly int[,] gridStatus = {
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {0, 0, 0, 1, 0, 0, 0},
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {1, 0, 0, 1, 0, 0, 1},
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {0, 0, 0, 1, 0, 0, 0},
                                                        {0, 0, 0, 0, 0, 0, 0}
                                                    };

        private static readonly int[,] gridStatus2 = {
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {0, 0, 1, 0, 1, 0, 0},
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {1, 0, 0, 0, 0, 0, 1},
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {0, 0, 1, 0, 1, 0, 0},
                                                        {0, 0, 0, 0, 0, 0, 0}
                                                    };
        private static readonly int[,] gridStatus3 = {
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {0, 0, 1, 0, 1, 0, 0},
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {1, 1, 0, 0, 0, 0, 1},
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {0, 0, 1, 0, 1, 0, 0},
                                                        {0, 0, 0, 0, 0, 0, 0}
                                                    };
        private static readonly int[,] gridStatus4 = {
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {0, 1, 0, 1, 0, 1, 0},
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {1, 0, 0, 0, 0, 0, 1},
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {0, 1, 0, 1, 0, 1, 0},
                                                        {0, 0, 0, 0, 0, 0, 0}
                                                    };
        private static readonly int[,] gridStatus5 = {
                                                        {0, 0, 0, 0, 0, 0, 0},
                                                        {0, 1, 0, 0, 0, 0, 0},
                                                        {0, 0, 0, 1, 0, 1, 0},
                                                        {1, 1, 0, 0, 0, 0, 1},
                                                        {0, 0, 0, 1, 0, 1, 0},
                                                        {0, 1, 0, 0, 0, 0, 0},
                                                        {0, 0, 0, 0, 0, 0, 0}
                                                    };
        public static int GetGridStatus(int i, int j)
        {
            return gridStatus[i, j];
        }

        public static int GetGridStatus2(int i, int j)
        {
            return gridStatus2[i, j];
        }

        public static int GetGridStatus3(int i, int j)
        {
            return gridStatus3[i, j];
        }

        public static int GetGridStatus4(int i, int j)
        {
            return gridStatus4[i, j];
        }

        public static int GetGridStatus5(int i, int j)
        {
            return gridStatus5[i, j];
        }

        public static List<Node> GetNode()
        {
            List<Node> listNode = new List<Node>();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (gridStatus[j, i] == 1)
                    {
                        Node node = new Node();
                        //node.Index = new Vector2(j, i);
                        listNode.Add(node);
                    }
                }
            }
            return listNode;
        }
    }
}