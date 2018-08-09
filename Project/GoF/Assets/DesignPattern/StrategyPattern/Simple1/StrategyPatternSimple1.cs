/*
* ==============================
* FileName:		StrategyPatternSimple1
* Author:		DuanBin
* CreateTime:	8/9/2018 3:40:52 PM
* Description:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPatternSimple1
{
	public class StrategyPatternSimple1 : MonoBehaviour {
	
		void Start () {
            int seed1 = 3;
            int seed2 = 30000;

            Player jack = new Player("Jack", new WinningStrategy(seed1));
            Player lucy = new Player("Lucy", new ProStrategy(seed2));

            for (int i = 0; i < 1000; i++)
            {
                Hand nextHand1 = jack.NextHand();
                Hand nextHand2 = lucy.NextHand();

                if (nextHand1.IsStrongerThan(nextHand2))
                {
                    Debug.Log("Winner:" + jack);
                    jack.Win();
                    lucy.Lose();
                }
                else if (nextHand2.IsStrongerThan(nextHand1))
                {
                    Debug.Log("Winner:" + lucy);
                    jack.Lose();
                    lucy.Win();
                }
                else
                {
                    Debug.Log("Even......");
                    jack.Even();
                    lucy.Even();
                }
            }

            Debug.Log("Total result:");
            Debug.Log(jack.ToString());
            Debug.Log(lucy.ToString());
		}
	}

    public class Hand
    {
        private static int HAND_VALUE_GUU = 0;   // ��ʾʯͷ��ֵ
        private static int HAND_VALUE_CHO = 0;   // ��ʾ������ֵ
        private static int HAND_VALUE_PAA = 0;   // ��ʾ����ֵ

        public static Hand[] hand = 
            {new Hand(HAND_VALUE_GUU), new Hand(HAND_VALUE_CHO) , new Hand(HAND_VALUE_PAA)}; // ��ʾ��ȭ�е�3��ʵ��
        public static string[] name = { "ʯͷ","����","��" };    //��ʾ��ȭ����������Ӧ���ַ���


        private int handValue;
        public Hand(int handValue)
        {
            this.handValue = handValue;
        }

        /// <summary>
        /// �������Ƶ�ֵ��ȡ��Ӧ��ʵ��
        /// </summary>
        /// <param name="handValue"></param>
        /// <returns></returns>
        public static Hand GetHand(int handValue)
        {
            return hand[handValue];
        }

        /// <summary>
        /// ��� this ʤ�� h,�򷵻� true
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public bool IsStrongerThan(Hand h)
        {
            return Fight(h) == 1;
        }

        /// <summary>
        /// ��� this ���� h���򷵻� true
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public bool IsWeakerThan(Hand h)
        {
            return Fight(h) == -1;
        }

        /// <summary>
        /// �Ʒ֣�ƽ 0��ʤ 1���� -1
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private int Fight(Hand h)
        {
            if (this == h)
            {
                return 0;
            }
            else if ((this.handValue + 1) % 3 == h.handValue)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        // ת��Ϊ����ֵ����Ӧ���ַ���
        public override string ToString()
        {
            return name[handValue];
        }
    }


    public interface Strategy
    {
        Hand nextHand();
        void Study(bool win);
    }

    public class WinningStrategy : Strategy
    {
        private System.Random _randowm;
        private bool _won = false;
        private Hand _preHand;

        public WinningStrategy(int seed)
        {
            _randowm = new System.Random(seed);
        }

        public Hand nextHand()
        {
            if (!_won)
            {
                _preHand = Hand.GetHand(_randowm.Next(3));
            }
            return _preHand;
        }

        public void Study(bool win)
        {
            _won = win;
        }
    }

    public class ProStrategy : Strategy
    {
        private System.Random _random;
        private int _preHandValue = 0;
        private int _currentHandValue = 0;

        private int[,] _history = {{ 1, 1, 1 },{ 1, 1, 1 }, { 1, 1, 1 } };

        public ProStrategy(int seed)
        {
            _random = new System.Random(seed);
        }

        public Hand nextHand()
        {
            int bet = _random.Next(GetSum(_currentHandValue));
            int handValue = 0;
            if (bet < _history[_currentHandValue,0])
            {
                handValue = 0;
            }
            else if (bet < _history[_currentHandValue,0] + _history[_currentHandValue,1])
            {
                handValue = 1;
            }
            else
            {
                handValue = 2;
            }

            _preHandValue = _currentHandValue;
            _currentHandValue = handValue;
            return Hand.GetHand(handValue);
        }

        public void Study(bool win)
        {
            if (win)
            {
                _history[_preHandValue, _currentHandValue]++;
            }
            else
            {
                _history[_preHandValue, (_currentHandValue + 1) % 3]++;
                _history[_preHandValue, (_currentHandValue + 2) % 3]++;
            }
        }

        private int GetSum(int hv)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _history[hv, i];
            }
            return sum;
        }
    }

    public class Player
    {
        private string _name;
        private Strategy _strategy;
        private int _winCount;
        private int _loseCount;
        private int _gameCount;

        // ���������Ͳ���
        public Player(string name,Strategy strategy)
        {
            _name = name;
            _strategy = strategy;
        }

        /// <summary>
        /// ���Ծ�����һ��Ҫ��������
        /// </summary>
        /// <returns></returns>
        public Hand NextHand()
        {
            return _strategy.nextHand();
        }

        /// <summary>
        /// ʤ
        /// </summary>
        public void Win()
        {
            _strategy.Study(true);
            _winCount++;
            _gameCount++;
        }

        /// <summary>
        /// ��
        /// </summary>
        public void Lose()
        {
            _strategy.Study(false);
            _loseCount++;
            _gameCount++;
        }

        /// <summary>
        /// ƽ
        /// </summary>
        public void Even()
        {
            _gameCount++;
        }

        public override string ToString()
        {
            return "[" + _name + ":" + _gameCount + " games, " + _winCount + " win, " + _loseCount + " lose" + "]";
        }
    }

}


