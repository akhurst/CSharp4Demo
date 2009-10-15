def get_RubyClass
	RubyClass.new
end

class RubyClass
  def concat_strings *s
    s.join
  end
  
  def print_message message
    puts message
  end
end