using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Extra3VariousViewModelDataTemplate
{
    public static class ViewFactory
    {
        #region Private Member Variables

        private static Dictionary<Type, UserControl> _viewCache = new Dictionary<Type, UserControl>();

        #endregion Private Member Variables

        #region Public Methods

        public static UserControl GetView( Type type )
        {
            UserControl view = null;

            if ( _viewCache.ContainsKey( type ) )
            {
                view = _viewCache[ type ];
            }
            else
            {
                view = Activator.CreateInstance( type ) as UserControl;

                if ( view == null )
                {
                    throw new InvalidOperationException( "Could not create user control type " + type );
                }

                _viewCache.Add( type, view );
                view = _viewCache[ type ];
            }

            return view;
        }

        #endregion Public Methods
    }
}
