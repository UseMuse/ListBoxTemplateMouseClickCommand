using System;

namespace ListBoxTemplateMouseClickCommand.ViewModel
{
    public abstract class ViewModelBase : OnPropertyChangedClass, IDisposable
    {
        protected ViewModelBase()
        {
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }
    }
}
