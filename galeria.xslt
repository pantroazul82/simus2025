<xsl:stylesheet
  version="1.0"
  exclude-result-prefixes="x d xsl ddwrt"
  xmlns:x="http://www.w3.org/2001/XMLSchema"
  xmlns:d="http://schemas.microsoft.com/sharepoint/dsp"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime">
  <xsl:template match="/">

    <div class="slider-wrapper">
      <div id="slider" class="nivoSlider">
        <xsl:for-each select=".//*">
          <xsl:variable name="source" select="substring-before(substring-after(@Image,'src=&quot;'),'&quot;')" />
          <xsl:text disable-output-escaping="yes"><![CDATA[<img src="]]></xsl:text>
          <xsl:value-of select="$source"/>
          <xsl:text disable-output-escaping="yes"><![CDATA[" title="#]]></xsl:text>
          <xsl:text disable-output-escaping="yes"><![CDATA[" />]]></xsl:text>
        </xsl:for-each>
      </div>
    </div>
    <xsl:for-each select=".//*">
      <div id="{$num}" class="nivo-html-caption">
        <xsl:value-of select="@ImageCaption" disable-output-escaping="yes"/>
      </div>
    </xsl:for-each>
    <xsl:text disable-output-escaping="yes"><![CDATA[<script type="text/javascript">
$(document).ready(function() {
    $('#slider').nivoSlider({
        effect: 'fade', // Specify sets like: 'fold,fade,sliceDown'
        animSpeed: 600, // Slide transition speed
        startSlide: 0, // Set starting Slide (0 index)
        directionNav: true, // Next & Prev navigation
        controlNav: true, // 1,2,3... navigation
        pauseOnHover: true, // Stop animation while hovering
        manualAdvance: false, // Force manual transitions
        prevText: 'Prev', // Prev directionNav text
        nextText: 'Next', // Next directionNav text
        randomStart: false, // Start on a random slide
                        pauseTime: 10000 // How long each slide will show
    });
});
</script>
 
<style>
.nivoSlider {
   height: 355px;
   left: 0;
   overflow: visible;
   position: relative;
   top: 0;
   width: 1000px;
}
 
.nivoSlider img {
   position: relative;
   top: 0;
   left: -1px;
   max-width: none;
   width: 1000px;
   height: auto;
   max-height: 350px;
}
 
.nivoSlider {
   position: relative;
   background: url(/SiteAssets/nivo/loading.gif) no-repeat 50% 50%;
}
 
.nivoSlider img {
   position: absolute;
   top: 0;
   left: 0;
   display: none;
}
 
.nivoSlider a {
   border: 0;
   display: block;
}
 
.slider-wrapper {
   padding-top: 35px;
}
 
/* If an image is wrapped in a link */
.nivoSlider .nivo-imageLink {
   position: absolute;
   top: 0;
   left: 0;
   width: 100%;
   height: 100%;
   border: 0;
   padding: 0;
   margin: 0;
   z-index: 6;
   display: none;
   background: #FFF;
   filter: alpha(opacity=0);
   opacity: 0;
}
 
/* The slices and boxes in the Slider */
.nivo-slice {
   display: block;
   position: absolute;
   z-index: 5;
   height: 100%;
   top: 0;
}
 
.nivo-box {
   display: block;
   position: absolute;
   z-index: 5;
   overflow: hidden;
}
 
.nivo-box img {
   display: block;
}
 
/* Caption styles */
.nivo-caption {
   background: none repeat scroll 0 0 #FFF;
   border-right: 5px solid #AFBD22;
   display: block !important;
   bottom: 25px;
   left: auto;
   opacity: 0.9 !important;
   overflow: visible;
   padding: 5px 10px;
   position: absolute;
   right: -23px;
   width: 450px;
   z-index: 15;
}
 
.nivo-caption p {
   margin: 0;
   color: #444 !important;
}
 
.nivo-caption a {
   display: inline !important;
}
 
.nivo-html-caption {
   display: none;
}
 
/* Direction nav styles (e.g. Next & Prev) */
.nivo-directionNav {
   display: block !important;
   z-index: 10 !important;
   position: relative;
   display: block;
   background: red !important;
}
 
.nivo-directionNav a {
   position: absolute;
   top: 0;
   z-index: 999;
   cursor: pointer;
}
 
.nivo-prevNav,.nivo-nextNav {
   height: 350px;
   width: 100px;
   display: block;
}
 
.nivo-prevNav {
   left: 0;
   display: block;
   text-indent: -9999em;
   z-index: 999;
   background: url(/SiteAssets/nivo/arrow-left.png) no-repeat center 125px;
   -ms-filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=30);
   filter: alpha(opacity=50);
   -moz-opacity: 0.5;
   -khtml-opacity: 0.5;
   opacity: 0.5;
}
 
.nivo-nextNav {
   right: 0;
   display: block;
   text-indent: -9999em;
   z-index: 999;
   background: url(/SiteAssets/nivo/arrow-right.png) no-repeat center 125px;
   -ms-filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=30);
   filter: alpha(opacity=50);
   -moz-opacity: 0.5;
   -khtml-opacity: 0.5;
   opacity: 0.5;
}
 
.nivo-prevNav:hover,.nivo-nextNav:hover {
   -ms-filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=100);
   filter: alpha(opacity=100);
   -moz-opacity: 1;
   -khtml-opacity: 1;
   opacity: 1;
}
 
.nivo-controlNav {
   position: absolute;
   right: 0;
   top: 353px;
   z-index: 9;
}
 
.nivo-controlNav a {
   cursor: pointer;
   background: url(/SiteAssets/nivo/bullet-off.jpg) no-repeat;
   height: 12px;
   width: 12px;
   margin-right: 3px;
   text-indent: -9999em;
   display: block;
   float: left;
}
 
.nivo-controlNav a.active {
   background: url(/SiteAssets/nivo/bullet-on.jpg) no-repeat;
   height: 12px;
   width: 12px;
   margin-right: 3px;
   text-indent: -9999em;
   display: block;
   float: left;
}
</style>
 
<script type="text/javascript">
// Paste Nivo slider plugin here
</script>
]]></xsl:text>

  </xsl:template>
</xsl:stylesheet>