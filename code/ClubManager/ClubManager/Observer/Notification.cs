using System.Web.UI.WebControls;

namespace ClubManager.Observer
{
    public class Notification : IObserver
    {
        private Label label;

        public Notification(Label lbl)
        {
            label = lbl;
        }

        public void Update(string message)
        {
            label.Text = "Notification : " + message;
        }
    }
}