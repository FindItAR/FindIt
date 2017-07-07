﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using UnityEngine.UI;

namespace HoloToolkit.UI.Keyboard
{
	public class SymbolDisableHighlight : MonoBehaviour
	{
		/// <summary>
		/// The text field to update.
		/// </summary>
		[SerializeField]
		private Text m_TextField;

		/// <summary>
		/// The color to switch to when the button is disabled.
		/// </summary>
		[SerializeField]
		private Color m_DisabledColor = Color.grey;

		/// <summary>
		/// The color the text field starts as.
		/// </summary>
		private Color m_StartingColor;

		/// <summary>
		/// The button to check for disabled/enabled.
		/// </summary>
		private Button m_Button;

		/// <summary>
		/// Standard Unity start.
		/// </summary>
		private void Start()
		{
			if (m_TextField != null)
			{
				m_StartingColor = m_TextField.color;
			}

			m_Button = this.GetComponentInParent<Button>();

			this.UpdateState();

			
		}

		/// <summary>
		/// Standard Unity update.
		/// </summary>
		private void Update()
		{
			this.UpdateState();
		}

		/// <summary>
		/// Updates the visual state of the text based on the buttons state.
		/// </summary>
		private void UpdateState()
		{
			if (m_TextField != null && m_Button != null)
			{
				m_TextField.color = m_Button.interactable ? m_StartingColor : m_DisabledColor;
			}
		}
	}
}
