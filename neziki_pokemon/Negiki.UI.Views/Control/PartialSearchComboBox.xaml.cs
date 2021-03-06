using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Negiki.UI.Views.Controls
{
    /// <summary>
    /// PartialSearchComboBox.xaml の相互作用ロジック
    /// </summary>
    public partial class PartialSearchComboBox : ComboBox
    {
        private TextBox _textBox = null;
        private Popup _popUp = null;

        public PartialSearchComboBox()
        {
            InitializeComponent();

            this.Loaded += delegate
            {
                _textBox = this.Template.FindName("PART_EditableTextBox", this) as TextBox;
                _popUp = this.Template.FindName("PART_Popup", this) as Popup;

                if (_textBox != null)
                {
                    _textBox.TextChanged += delegate
                    {
                        if (!_popUp.IsOpen && string.IsNullOrEmpty(_textBox.Text))
                        {
                            // プログラムの処理によってコンボボックス内のテキストが空に上書きされた場合、ここに入る。
                            // この処理がないと、コンボボックス内のテキストを空に上書きするときにプルダウンが開いてしまう。
                            this.Items.Filter += obj =>
                            {
                                // プルダウン部分へ適用されているフィルターを解除する。
                                return true;
                            };

                            return;
                        }

                        // 入力がある都度、即時フィルターをかける。
                        this.Items.Filter += obj =>
                        {
                            if (!(obj is ComboBoxItem))
                            {
                                return true;
                            }

                            var item = obj as ComboBoxItem;
                            if (((string)item.Content).Contains(_textBox.Text))
                            {
                                //「選択肢の文字列の中に入力された文字列が含まれる場合」にフィルターを通過させる。
                                // フィルターを通過すると、展開された選択肢の中に表示される。
                                return true;
                            }

                            return false;
                        };

                        _popUp.IsOpen = true;
                    };

                    _textBox.GotFocus += delegate
                    {
                        if (!_popUp.IsOpen)
                        {
                            // コンボボックスの入力欄にフォーカスが当たったとき、プルダウンを展開する。
                            _popUp.IsOpen = true;
                        }
                    };
                }
            };
        }
    }
}
