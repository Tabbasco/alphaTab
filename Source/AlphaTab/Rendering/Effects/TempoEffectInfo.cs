﻿/*
 * This file is part of alphaTab.
 * Copyright (c) 2014, Daniel Kuschny and Contributors, All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or at your option any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */
using AlphaTab.Model;
using AlphaTab.Rendering.Glyphs;

namespace AlphaTab.Rendering.Effects
{
    public class TempoEffectInfo : IEffectBarRendererInfo
    {
        public string EffectId { get { return "tempo"; } }
        public bool HideOnMultiTrack { get { return true; } }
        public bool CanShareBand { get { return false; } }
        public EffectBarGlyphSizing SizingMode { get { return EffectBarGlyphSizing.SinglePreBeat; } }

        public bool ShouldCreateGlyph(Beat beat)
        {
            return beat.Voice.Bar.Staff.Index == 0 && beat.Voice.Index == 0 && beat.Index == 0 && (beat.Voice.Bar.MasterBar.TempoAutomation != null || beat.Voice.Bar.Index == 0);
        }
       
        public EffectGlyph CreateNewGlyph(BarRendererBase renderer, Beat beat)
        {
            int tempo;
            if (beat.Voice.Bar.MasterBar.TempoAutomation != null)
            {
                tempo = (int)(beat.Voice.Bar.MasterBar.TempoAutomation.Value);
            }
            else
            {
                tempo = beat.Voice.Bar.Staff.Track.Score.Tempo;
            }
            return new TempoGlyph(0, 0, tempo);
        }

        public bool CanExpand(Beat @from, Beat to)
        {
            return true;
        }
    }
}