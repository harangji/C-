//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _20250123_homework_2
//{

//    public class Genealogy
//    {
//        //높은 무늬의 순서 ♠(스페이드) > ◆(다이아) > ♥(하트) > ♣(클로버)
//        //높은 숫자의 순서 A > K > Q > J > 10~2
//        //승리조건 : 족보가 더 높은 쪽-> 서로 같을경우 숫자 높은쪽-> 문양비교

//        //아래 족보를 순서대로 논리체크 => 원페어부터 검사할경우 원페어가 포함되는 족보를 전부 확인해야 하기 때문에 
//        //상위 조합에 포함되는 하위 조합의 if문을 가져와서 사용하기

//        //10. 로얄 플러쉬       => 플러쉬 + 특수조합AQKJ10
//        //9. 스트레이트 플러쉬  => 스트레이트 + 플러쉬
//        //8. 포카드             => 같은숫자 4장
//        //7. 풀하우스           => 트리플 + 원페어
//        //6. 플러쉬             => 같은문양 5장
//        //5. 스트레이트         => 연속되는 숫자 5장
//        //4. 트리플             => 같은 숫자 3장
//        //3. 투페어             => 원페어 *2
//        //2. 원페어             => 같은 숫자 두장
//        //1. 하이카드           => 가장 높은 카드의 점수



//            public string EvaluateHand()
//            {
//                if (RoyalFlush()) return "로열 플러시";
//                if (StraightFlush()) return "스트레이트 플러시";
//                if (FourOfAKind()) return "포카드";
//                if (FullHouse()) return "풀 하우스";
//                if (Flush()) return "플러시";
//                if (Straight()) return "스트레이트";
//                if (ThreeOfAKind()) return "쓰리 오브 어 카인드";
//                if (TwoPair()) return "투 페어";
//                if (OnePair()) return "원 페어";
//                return "하이 카드";
//            }

//            private bool OnePair()
//            {
//                return 
//            }

//            private bool TwoPair()
//            {
//                return false;
//            }

//        }
//    }
//}