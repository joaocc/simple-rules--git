http://code.google.com/p/simple-rules/

# Project members authenticate over HTTPS to allow committing changes.
svn checkout https://simple-rules.googlecode.com/svn/trunk/ simple-rules

# Non-members may check out a read-only working copy anonymously over HTTP.
svn checkout http://simple-rules.googlecode.com/svn/trunk/ simple-rules-read-only

