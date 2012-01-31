﻿using System;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using uComponents.Core.Shared;
using uComponents.Core.Shared.PrevalueEditors;
using umbraco.cms.businesslogic.datatype;

namespace uComponents.Core.DataTypes.CharLimit
{
	/// <summary>
	/// The PreValue Editor for the CharLimit data-type.
	/// </summary>
	public class CharLimitPrevalueEditor : AbstractJsonPrevalueEditor
	{
		/// <summary>
		/// The TextBox control for the character limit of the data-type.
		/// </summary>
		private TextBox CharLimitValue;

		/// <summary>
		/// The RadioButtonList for the TextBoxMode of the data-type.
		/// </summary>
		private RadioButtonList TextBoxModeList;

		/// <summary>
		/// Initializes a new instance of the <see cref="CharLimitPrevalueEditor"/> class.
		/// </summary>
		/// <param name="dataType">Type of the data.</param>
		public CharLimitPrevalueEditor(BaseDataType dataType)
			: base(dataType, DBTypes.Ntext)
		{
		}

		/// <summary>
		/// Saves the data-type PreValue options.
		/// </summary>
		public override void Save()
		{
			// set the options
			var options = new CharLimitOptions(true);

			// parse the char limit
			int limit;
			if (int.TryParse(this.CharLimitValue.Text, out limit))
			{
				if (limit == 0)
				{
					limit = 100;
				}

				options.Limit = limit;
			}

			// set the TextBoxMode
			if (this.TextBoxModeList.SelectedValue == "MultiLine")
			{
				options.TextBoxMode = TextBoxMode.MultiLine;
			}
			else
			{
				options.TextBoxMode = TextBoxMode.SingleLine;
			}

			// save the options as JSON
			this.SaveAsJson(options);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.EnsureChildControls();
		}

		/// <summary>
		/// Creates child controls for this control
		/// </summary>
		protected override void CreateChildControls()
		{
			base.CreateChildControls();

			// set-up child controls
			this.CharLimitValue = new TextBox() { ID = "TextBoxCharLimit", CssClass = "guiInputText" };
			this.TextBoxModeList = new RadioButtonList() { ID = "TextBoxModeList" };

			// populate the controls
			this.TextBoxModeList.Items.Clear();
			this.TextBoxModeList.Items.Add(TextBoxMode.SingleLine.ToString());
			this.TextBoxModeList.Items.Add(TextBoxMode.MultiLine.ToString());

			// add the child controls
			this.Controls.AddPrevalueControls(this.CharLimitValue, this.TextBoxModeList);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Web.UI.Control.Load"/> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs"/> object that contains the event data.</param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// get PreValues, load them into the controls.
			var options = this.GetPreValueOptions<CharLimitOptions>();

			// no options? use the default ones.
			if (options == null)
			{
				options = new CharLimitOptions(true);
			}

			// set the values
			this.CharLimitValue.Text = options.Limit.ToString();
			this.TextBoxModeList.SelectedValue = options.TextBoxMode.ToString();
		}

		/// <summary>
		/// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
		/// </summary>
		/// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			// add property fields
			writer.AddPrevalueRow("Character Limit:", this.CharLimitValue);
			writer.AddPrevalueRow("TextBox Mode:", this.TextBoxModeList);
		}
	}
}