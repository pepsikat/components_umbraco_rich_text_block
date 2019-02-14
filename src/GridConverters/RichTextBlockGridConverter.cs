using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Config;
using Skybrud.Umbraco.GridData.Interfaces;
using Skybrud.Umbraco.GridData.Rendering;
using Skybrud.Umbraco.GridData.Values;

namespace Graph.Components.RichtextBlock
{
	public class RichTextBlockGridConverter : IGridConverter
	{
		public bool ConvertControlValue(GridControl control, JToken token, out IGridControlValue value)
		{
			value = null;

			if (control.Editor.Alias == "richtextBlock")
			{
				value = GridControlRichTextValue.Parse(control, token);
			}

			return value != null;
		}

		public bool ConvertEditorConfig(GridEditor editor, JToken token, out IGridEditorConfig config)
		{
			config = null;

			if (editor.Alias == "richtextBlock")
			{
				config = GridEditorTextConfig.Parse(editor, token as JObject);
			}

			return config != null;
		}

		public bool GetControlWrapper(GridControl control, out GridControlWrapper wrapper)
		{
			wrapper = null;

			if (control.Editor.Alias == "richtextBlock")
			{
				wrapper = control.GetControlWrapper<GridControlRichTextValue>();
			}

			return wrapper != null;
		}
	}
}
