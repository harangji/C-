using System.Collections.Generic;

namespace PM_Simulation.Resource
{
    class Comment
    {
        // 코멘트의 유형을 나타내는 열거형
        public enum CommentType
        {
            Positive,
            Negative
        }

        // 코멘트 내용과 유형을 저장
        public string Content { get; set; }
        public CommentType Type { get; set; }

        // 생성자
        public Comment(string content, CommentType type)
        {
            Content = content;
            Type = type;
        }

        // 긍정적인 코멘트 리스트
        public static List<Comment> GetPositiveComments()
        {
            return new List<Comment>
            {
                new Comment("이 포켓몬은 정말 강하고 멋져요! 앞으로도 계속 사용할게요!", CommentType.Positive),
                new Comment("대결에서 정말 훌륭한 성과를 보였어요! 승리를 축하합니다!", CommentType.Positive),
                new Comment("이번 전투에서 이 포켓몬의 활약이 돋보였어요. 앞으로가 기대돼요!", CommentType.Positive),
                new Comment("너무 강력한 포켓몬이에요. 더 많은 대결에서 승리할 것 같아요!", CommentType.Positive),
                new Comment("이 포켓몬은 정말 뛰어난 성과를 보여줬어요. 꼭 써볼 가치가 있어요.", CommentType.Positive)
            };
        }

        // 부정적인 코멘트 리스트
        public static List<Comment> GetNegativeComments()
        {
            return new List<Comment>
            {
                new Comment("너무 약해서 상대방에게 쉽게 지네요. 다시 훈련이 필요해요.", CommentType.Negative),
                new Comment("이번 대결은 정말 실망스러웠어요. 더 많은 훈련이 필요할 것 같아요.", CommentType.Negative),
                new Comment("이 포켓몬은 너무 자주 지네요. 다른 포켓몬을 써야 할 듯...", CommentType.Negative),
                new Comment("승률이 너무 낮아요. 이 포켓몬은 더 강해져야 할 필요가 있어요.", CommentType.Negative),
                new Comment("전투에서 너무 약해요. 다른 전략을 찾는 것이 좋겠어요.", CommentType.Negative)
            };
        }
    }
}
