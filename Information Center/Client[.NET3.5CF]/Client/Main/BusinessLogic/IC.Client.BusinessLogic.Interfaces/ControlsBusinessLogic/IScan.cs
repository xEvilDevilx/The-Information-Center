using IC.Client.FormModel.Base.EventHandlers;

namespace IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic
{
    /// <summary>
    /// Presents Scan Business Logic interface
    /// 
    /// 2017/08/14 - Created, VTyagunov
    /// </summary>
    public interface IScan : IControlBusinessLogic
    {
        /// <summary>Send Language and Currency Data Event</summary>
        event ControlEventHandlers.SendLangCurrDataEventHandler SendLangCurrDataEvent;
    }
}