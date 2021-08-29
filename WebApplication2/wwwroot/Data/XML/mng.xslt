<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <html>
            <head>
                <title>
                    <xsl:value-of select="testcase"/>
                </title>
            </head>
            <body>
                <xsl:apply-templates select="body"/>
            </body>
        </html>
    </xsl:template>
    <xsl:template match="testcase">
        <h1><xsl:value-of select="."/></h1>
    </xsl:template>
    <xsl:template match="error">
        <p><xsl:apply-templates/></p>
    </xsl:template>
</xsl:stylesheet>