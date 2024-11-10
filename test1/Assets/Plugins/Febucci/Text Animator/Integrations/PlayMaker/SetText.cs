using HutongGames.PlayMaker;

namespace Febucci.UI.PlayMaker
{
    [ActionCategory("TextAnimator")]
    [HutongGames.PlayMaker.Tooltip("Sets a text via TextAnimator")]
    public class SetText : FsmStateAction
    {
        [UIHint(UIHint.TextArea)]
        public FsmString textToShow;

        [RequiredField, UIHint(UIHint.ScriptComponent)]
        public TextAnimatorPlayer textAnimPlayer;

        public override void OnEnter()
        {
            base.OnEnter();
            textAnimPlayer.ShowText(textToShow.Value);
            textAnimPlayer.onTextShowed.AddListener(Finish);
        }

        public override void OnExit()
        {
            base.OnExit();
            textAnimPlayer.onTextShowed.RemoveListener(Finish);
            textAnimPlayer.StopShowingText();
        }
    }

}
