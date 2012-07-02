package alphatab.rendering.glyphs;
import alphatab.model.Duration;

/**
 * ...
 * @author Daniel Kuschny
 */

class NoteHeadGlyph extends SvgGlyph
{
	public function new(x:Int = 0, y:Int = 0, duration:Duration)
	{
		super(x, y, getNoteSvg(duration), 1, 1);
	}	
	
		
	public override function doLayout():Void 
	{
		width = Std.int(9 * getScale());
	}
	
	public override function applyGlyphSpacing(spacing:Int):Void 
	{
	}
	
	private function getNoteSvg(duration:Duration) : String
	{
		switch(duration)
		{
            case Whole: return MusicFont.NoteHalf;
            case Half: return MusicFont.NoteHalf;
            default: return MusicFont.NoteQuarter;
		}
	}
}