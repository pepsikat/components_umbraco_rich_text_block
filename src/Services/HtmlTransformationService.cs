using HtmlTransformation;
using HtmlTransformation.Rules;

namespace Graph.Components.RichtextBlock
{
	public static class HtmlTransformationService
	{
		private static Transformation Default
		{
			get
			{
				var result = new Transformation();
				result.AddRule(new RemoveFontRule());
				result.AddRule(new RemoveAttributeRule("*", "style"));
				result.AddRule(new TrimSpacesInsideBlockRule());
				result.AddRule(new RemoveDivWithoutAnyAttrAndAddBrAfterTheContentRule());
				result.AddRule(new ReplaceAnyLineWithWhiteSpaceCharactersOnlyAndNbspWithBrRule());
				result.AddRule(new ReplaceWhiteSpaceTextNodesBetweenTwoBrRule());
				result.AddRule(new WrapTextNodeInPRule());
				result.AddRule(new ReplaceBrWithPRule());
				result.AddRule(new AddIframeWrapperRule());
				result.AddRule(new AddMarkupClassAttributeRule("markup-"));

				return result;
			}
		}

		private static Transformation Media
		{
			get
			{
				var result = new Transformation();
				result.AddRule(new AddIframeWrapperRule());
				result.AddRule(new AddMarkupClassAttributeRule("markup-"));

				return result;
			}
		}

		public static string Apply(string text, string additionalClass = null)
		{
			return InternalApply(text, Default, additionalClass);
		}

		public static string ApplyForMedia(string text, string additionalClass = null)
		{
			return InternalApply(text, Media, additionalClass);
		}

		private static string InternalApply(string text, Transformation transformation, string additionalClass)
		{

			if (string.IsNullOrEmpty(additionalClass) == false)
			{
				transformation.AddRule(new AddAdditionalClassAttributeRule("markup-", additionalClass));
			}

			return transformation.TransformHtml(text);
		}
	}
}
